using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using LifeFlowBBMS.DAL;

namespace LifeFlowBBMS.UI
{
    public partial class FrmUserManagement : Form
    {
        private int _selectedUserId = -1;

        public FrmUserManagement()
        {
            InitializeComponent();
        }

        private void FrmUserManagement_Load(object sender, EventArgs e)
        {
            StyleGrid();
            LoadUsers();
        }

        // ─────────────────────────────────────────────────
        //  STYLE GRID
        // ─────────────────────────────────────────────────
        private void StyleGrid()
        {
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor =
                Color.Maroon;
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvUsers.DefaultCellStyle.SelectionBackColor =
                Color.Firebrick;
            dgvUsers.DefaultCellStyle.SelectionForeColor =
                Color.White;
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(255, 245, 245);
        }

        // ─────────────────────────────────────────────────
        //  LOAD USERS
        // ─────────────────────────────────────────────────
        private void LoadUsers(string search = "")
        {
            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT UserID, FullName, Username, RoleName,
                               CASE WHEN IsActive=1 THEN 'Yes' ELSE 'No' END AS Active
                        FROM   Users";

                    if (!string.IsNullOrEmpty(search))
                        query += @" WHERE FullName  LIKE @search
                                       OR Username  LIKE @search
                                       OR RoleName  LIKE @search";

                    query += " ORDER BY FullName";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    if (!string.IsNullOrEmpty(search))
                        da.SelectCommand.Parameters.AddWithValue(
                            "@search", "%" + search + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUsers.DataSource = dt;

                    if (dgvUsers.Columns.Count > 0)
                    {
                        dgvUsers.Columns["UserID"].HeaderText = "ID";
                        dgvUsers.Columns["UserID"].Width = 50;
                        dgvUsers.Columns["FullName"].HeaderText = "Full Name";
                        dgvUsers.Columns["FullName"].Width = 200;
                        dgvUsers.Columns["Username"].HeaderText = "Username";
                        dgvUsers.Columns["Username"].Width = 160;
                        dgvUsers.Columns["RoleName"].HeaderText = "Role";
                        dgvUsers.Columns["RoleName"].Width = 120;
                        dgvUsers.Columns["Active"].HeaderText = "Active";
                        dgvUsers.Columns["Active"].Width = 80;
                    }

                    // Color active/inactive
                    foreach (DataGridViewRow row in dgvUsers.Rows)
                    {
                        string active = row.Cells["Active"].Value?.ToString();
                        row.DefaultCellStyle.ForeColor = active == "Yes"
                            ? Color.DarkGreen : Color.DarkRed;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────
        //  SHA256 HASH — matches your existing login
        // ─────────────────────────────────────────────────
        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        // ─────────────────────────────────────────────────
        //  ADD USER
        // ─────────────────────────────────────────────────
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Full Name, Username, Password and Role are required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();

                    // Check duplicate username
                    SqlCommand chk = new SqlCommand(
                        "SELECT COUNT(*) FROM Users WHERE Username = @uname", con);
                    chk.Parameters.AddWithValue("@uname",
                        txtUsername.Text.Trim().ToLower());
                    if (Convert.ToInt32(chk.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("Username already exists. Choose a different one.",
                            "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    SqlCommand cmd = new SqlCommand(@"
                        INSERT INTO Users
                            (FullName, Username, PasswordHash, RoleName, IsActive)
                        VALUES
                            (@full, @uname, @pass, @role, @active)", con);
                    cmd.Parameters.AddWithValue("@full",
                        txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@uname",
                        txtUsername.Text.Trim().ToLower());
                    cmd.Parameters.AddWithValue("@pass",
                        HashPassword(txtPassword.Text.Trim()));
                    cmd.Parameters.AddWithValue("@role",
                        cmbRole.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@active",
                        chkActive.Checked ? 1 : 0);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("User added successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────
        //  UPDATE USER
        // ─────────────────────────────────────────────────
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedUserId < 0) return;

            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Full Name, Username and Role are required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();

                    // If password field is filled → update password too
                    // If left blank → keep existing password
                    string sql;
                    SqlCommand cmd;

                    if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        sql = @"UPDATE Users
                                SET    FullName     = @full,
                                       Username     = @uname,
                                       PasswordHash = @pass,
                                       RoleName     = @role,
                                       IsActive     = @active
                                WHERE  UserID       = @id";
                        cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@pass",
                            HashPassword(txtPassword.Text.Trim()));
                    }
                    else
                    {
                        sql = @"UPDATE Users
                                SET    FullName = @full,
                                       Username = @uname,
                                       RoleName = @role,
                                       IsActive = @active
                                WHERE  UserID   = @id";
                        cmd = new SqlCommand(sql, con);
                    }

                    cmd.Parameters.AddWithValue("@full",
                        txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@uname",
                        txtUsername.Text.Trim().ToLower());
                    cmd.Parameters.AddWithValue("@role",
                        cmbRole.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@active",
                        chkActive.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@id", _selectedUserId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    string.IsNullOrWhiteSpace(txtPassword.Text)
                        ? "User updated. Password unchanged."
                        : "User updated with new password!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────
        //  DELETE USER
        // ─────────────────────────────────────────────────
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedUserId < 0) return;

            if (MessageBox.Show(
                "Are you sure you want to delete this user?\nThis cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Users WHERE UserID = @id", con);
                    cmd.Parameters.AddWithValue("@id", _selectedUserId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("User deleted successfully.",
                    "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting user: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────
        //  GRID CLICK — load row into form
        // ─────────────────────────────────────────────────
        private void dgvUsers_CellClick(object sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
            _selectedUserId = Convert.ToInt32(row.Cells["UserID"].Value);

            txtFullName.Text = row.Cells["FullName"].Value?.ToString() ?? "";
            txtUsername.Text = row.Cells["Username"].Value?.ToString() ?? "";
            txtPassword.Text = "";   // Never show hashed password

            string role = row.Cells["RoleName"].Value?.ToString() ?? "";
            cmbRole.SelectedIndex = cmbRole.Items.IndexOf(role);

            chkActive.Checked = row.Cells["Active"].Value?.ToString() == "Yes";

            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
        }

        // ─────────────────────────────────────────────────
        //  SEARCH
        // ─────────────────────────────────────────────────
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadUsers(txtSearch.Text.Trim());
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadUsers();
        }

        // ─────────────────────────────────────────────────
        //  CLEAR
        // ─────────────────────────────────────────────────
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            _selectedUserId = -1;
            txtFullName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;
            chkActive.Checked = true;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }
    }
}