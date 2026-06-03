using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using LifeFlowBBMS.DAL;

namespace LifeFlowBBMS.UI
{
    public class FrmAddEditUser : Form
    {
        private int _userId = -1;

        private Panel pnlTop;
        private Label lblTitle;
        private Label lblFullName, lblUsername, lblPassword, lblRole, lblIsActive;
        private TextBox txtFullName, txtUsername, txtPassword;
        private ComboBox cmbRole;
        private CheckBox chkIsActive;
        private Button btnSave, btnCancel;

        public FrmAddEditUser(int userId = -1)
        {
            _userId = userId;
            BuildForm();
            if (_userId != -1)
                LoadUserData();
        }

        // ─────────────────────────────────────────────────
        //  SHA256 HASH
        // ─────────────────────────────────────────────────
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        private void BuildForm()
        {
            this.Text = _userId == -1 ? "Add User" : "Edit User";
            this.ClientSize = new Size(460, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Font = new Font("Segoe UI", 10F);

            pnlTop = new Panel
            {
                BackColor = Color.Firebrick,
                Dock = DockStyle.Top,
                Height = 55
            };
            lblTitle = new Label
            {
                Text = _userId == -1 ? "Add New User" : "Edit User",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 12),
                AutoSize = true
            };
            pnlTop.Controls.Add(lblTitle);

            int left = 30, ctrlX = 160, ctrlW = 260, gap = 50, top = 75;

            lblFullName = MakeLabel("Full Name *", left, top);
            txtFullName = new TextBox { Location = new Point(ctrlX, top - 3), Size = new Size(ctrlW, 26) };

            lblUsername = MakeLabel("Username *", left, top + gap);
            txtUsername = new TextBox { Location = new Point(ctrlX, top + gap - 3), Size = new Size(ctrlW, 26) };

            lblPassword = MakeLabel(_userId == -1 ? "Password *" : "New Password", left, top + gap * 2);
            txtPassword = new TextBox
            {
                Location = new Point(ctrlX, top + gap * 2 - 3),
                Size = new Size(ctrlW, 26),
                PasswordChar = '●'
            };

            lblRole = MakeLabel("Role *", left, top + gap * 3);
            cmbRole = new ComboBox
            {
                Location = new Point(ctrlX, top + gap * 3 - 3),
                Size = new Size(150, 26),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbRole.Items.AddRange(new object[] { "Admin", "Staff" });
            cmbRole.SelectedIndex = 1;

            lblIsActive = MakeLabel("Status", left, top + gap * 4);
            chkIsActive = new CheckBox
            {
                Text = "Active",
                Location = new Point(ctrlX, top + gap * 4 - 3),
                AutoSize = true,
                Checked = true
            };

            btnSave = new Button
            {
                Text = "Save",
                Location = new Point(155, top + gap * 5 + 10),
                Size = new Size(120, 36),
                BackColor = Color.Firebrick,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(290, top + gap * 5 + 10),
                Size = new Size(100, 36),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F)
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.AddRange(new Control[] {
                pnlTop,
                lblFullName,  txtFullName,
                lblUsername,  txtUsername,
                lblPassword,  txtPassword,
                lblRole,      cmbRole,
                lblIsActive,  chkIsActive,
                btnSave,      btnCancel
            });
        }

        private Label MakeLabel(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                ForeColor = Color.FromArgb(60, 60, 60),
                Font = new Font("Segoe UI", 10F)
            };
        }

        private void LoadUserData()
        {
            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT * FROM Users WHERE UserID = @id", con);
                    cmd.Parameters.AddWithValue("@id", _userId);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        txtFullName.Text = dr["FullName"].ToString();
                        txtUsername.Text = dr["Username"].ToString();
                        cmbRole.SelectedItem = dr["RoleName"].ToString();
                        chkIsActive.Checked = Convert.ToBoolean(dr["IsActive"]);
                        // Password left blank for security
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Full Name and Username are required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_userId == -1 && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required for new user.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    SqlCommand cmd;

                    if (_userId == -1)
                    {
                        cmd = new SqlCommand(@"INSERT INTO Users
                            (FullName, Username, PasswordHash, RoleName, IsActive)
                            VALUES (@fullname, @username, @password, @role, @isactive)", con);
                        cmd.Parameters.AddWithValue("@password",
                            HashPassword(txtPassword.Text.Trim()));
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            cmd = new SqlCommand(@"UPDATE Users SET
                                FullName=@fullname, Username=@username,
                                PasswordHash=@password, RoleName=@role,
                                IsActive=@isactive
                                WHERE UserID=@id", con);
                            cmd.Parameters.AddWithValue("@password",
                                HashPassword(txtPassword.Text.Trim()));
                        }
                        else
                        {
                            cmd = new SqlCommand(@"UPDATE Users SET
                                FullName=@fullname, Username=@username,
                                RoleName=@role, IsActive=@isactive
                                WHERE UserID=@id", con);
                        }
                        cmd.Parameters.AddWithValue("@id", _userId);
                    }

                    cmd.Parameters.AddWithValue("@fullname", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@isactive", chkIsActive.Checked);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    _userId == -1 ? "User added successfully!" : "User updated successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving user: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}