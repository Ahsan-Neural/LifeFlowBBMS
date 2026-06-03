using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using LifeFlowBBMS.DAL;

namespace LifeFlowBBMS.UI
{
    public partial class FrmDonorManagement : Form
    {
        private int _editingId = -1;

        public FrmDonorManagement()
        {
            InitializeComponent();
        }

        private void FrmDonorManagement_Load(object sender, EventArgs e)
        {
            StyleGrid();
            dtpDOB.ValueChanged += (s, ev) => CalculateAge();
            LoadDonors();
        }

        // ─────────────────────────────────────────────────
        //  STYLE GRID
        // ─────────────────────────────────────────────────
        private void StyleGrid()
        {
            dgvDonors.EnableHeadersVisualStyles = false;
            dgvDonors.ColumnHeadersDefaultCellStyle.BackColor = Color.Maroon;
            dgvDonors.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDonors.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvDonors.DefaultCellStyle.SelectionBackColor = Color.Firebrick;
            dgvDonors.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDonors.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(255, 245, 245);
        }

        // ─────────────────────────────────────────────────
        //  CALCULATE AGE FROM DOB
        // ─────────────────────────────────────────────────
        private void CalculateAge()
        {
            int age = DateTime.Now.Year - dtpDOB.Value.Year;
            if (dtpDOB.Value.Date > DateTime.Now.AddYears(-age)) age--;
            txtAge.Text = age.ToString();
        }

        // ─────────────────────────────────────────────────
        //  LOAD DONORS
        // ─────────────────────────────────────────────────
        private void LoadDonors(string search = "")
        {
            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT DonorID, FullName, FatherName, Gender,
                               BloodGroup, Phone, Email, City, Address,
                               LastDonationDate,
                               CASE WHEN IsEligible=1 THEN 'Yes' ELSE 'No' END AS Eligible
                        FROM   Donors";

                    if (!string.IsNullOrWhiteSpace(search))
                        query += @" WHERE FullName     LIKE @s
                                       OR BloodGroup   LIKE @s
                                       OR Phone        LIKE @s
                                       OR City         LIKE @s";

                    query += " ORDER BY DonorID DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    if (!string.IsNullOrWhiteSpace(search))
                        da.SelectCommand.Parameters.AddWithValue("@s",
                            "%" + search + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDonors.DataSource = dt;

                    // ── Fixed column widths — total ~1350px → triggers H-scroll ──
                    if (dgvDonors.Columns.Count > 0)
                    {
                        dgvDonors.Columns["DonorID"].HeaderText = "ID";
                        dgvDonors.Columns["DonorID"].Width = 50;

                        dgvDonors.Columns["FullName"].HeaderText = "Full Name";
                        dgvDonors.Columns["FullName"].Width = 160;

                        dgvDonors.Columns["FatherName"].HeaderText = "Father Name";
                        dgvDonors.Columns["FatherName"].Width = 140;

                        dgvDonors.Columns["Gender"].HeaderText = "Gender";
                        dgvDonors.Columns["Gender"].Width = 80;

                        dgvDonors.Columns["BloodGroup"].HeaderText = "Blood Group";
                        dgvDonors.Columns["BloodGroup"].Width = 95;

                        dgvDonors.Columns["Phone"].HeaderText = "Phone";
                        dgvDonors.Columns["Phone"].Width = 135;

                        dgvDonors.Columns["Email"].HeaderText = "Email";
                        dgvDonors.Columns["Email"].Width = 190;

                        dgvDonors.Columns["City"].HeaderText = "City";
                        dgvDonors.Columns["City"].Width = 110;

                        dgvDonors.Columns["Address"].HeaderText = "Address";
                        dgvDonors.Columns["Address"].Width = 200;

                        dgvDonors.Columns["LastDonationDate"].HeaderText = "Last Donation";
                        dgvDonors.Columns["LastDonationDate"].Width = 110;
                        dgvDonors.Columns["LastDonationDate"]
                            .DefaultCellStyle.Format = "dd/MM/yyyy";

                        dgvDonors.Columns["Eligible"].HeaderText = "Eligible";
                        dgvDonors.Columns["Eligible"].Width = 70;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading donors: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────
        //  ADD DONOR
        // ─────────────────────────────────────────────────
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                cmbBloodType.SelectedIndex == -1)
            {
                MessageBox.Show("Full Name and Blood Type are required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    string query = @"
                        INSERT INTO Donors
                            (FullName, FatherName, Gender, DOB, BloodGroup,
                             Phone, Email, City, Address,
                             LastDonationDate, IsEligible)
                        VALUES
                            (@name, @father, @gender, @dob, @blood,
                             @phone, @email, @city, @address,
                             @dondate, @eligible)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name",
                        txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@father",
                        string.IsNullOrWhiteSpace(txtFather.Text)
                            ? (object)DBNull.Value : txtFather.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender",
                        cmbGender.SelectedIndex >= 0
                            ? cmbGender.SelectedItem.ToString()
                            : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@dob", dtpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@blood", cmbBloodType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@phone",
                        string.IsNullOrWhiteSpace(txtPhone.Text)
                            ? (object)DBNull.Value : txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@email",
                        string.IsNullOrWhiteSpace(txtEmail.Text)
                            ? (object)DBNull.Value : txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@city",
                        string.IsNullOrWhiteSpace(txtCity.Text)
                            ? (object)DBNull.Value : txtCity.Text.Trim());
                    cmd.Parameters.AddWithValue("@address",
                        string.IsNullOrWhiteSpace(txtAddress.Text)
                            ? (object)DBNull.Value : txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@dondate", dtpDonDate.Value.Date);
                    cmd.Parameters.AddWithValue("@eligible", chkEligible.Checked ? 1 : 0);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Donor added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadDonors();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding donor: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────
        //  ROW CLICK — fill form for editing
        // ─────────────────────────────────────────────────
        private void dgvDonors_CellClick(object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvDonors.Rows[e.RowIndex];
            _editingId = Convert.ToInt32(row.Cells["DonorID"].Value);

            txtName.Text = row.Cells["FullName"].Value?.ToString() ?? "";
            txtFather.Text = row.Cells["FatherName"].Value?.ToString() ?? "";
            txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
            txtCity.Text = row.Cells["City"].Value?.ToString() ?? "";
            txtAddress.Text = row.Cells["Address"].Value?.ToString() ?? "";

            string gen = row.Cells["Gender"].Value?.ToString() ?? "";
            cmbGender.SelectedIndex = cmbGender.Items.IndexOf(gen);

            string bg = row.Cells["BloodGroup"].Value?.ToString() ?? "";
            cmbBloodType.SelectedIndex = cmbBloodType.Items.IndexOf(bg);

            chkEligible.Checked =
                row.Cells["Eligible"].Value?.ToString() == "Yes";

            if (row.Cells["LastDonationDate"].Value != null &&
                row.Cells["LastDonationDate"].Value != DBNull.Value)
                dtpDonDate.Value = Convert.ToDateTime(
                    row.Cells["LastDonationDate"].Value);

            LoadDOBForEdit(_editingId);

            btnAdd.Visible = false;
            btnEdit.Visible = true;
            btnCancelEdit.Visible = true;
        }

        private void LoadDOBForEdit(int donorId)
        {
            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT DOB FROM Donors WHERE DonorID=@id", con);
                    cmd.Parameters.AddWithValue("@id", donorId);
                    object val = cmd.ExecuteScalar();
                    if (val != null && val != DBNull.Value)
                    {
                        dtpDOB.Value = Convert.ToDateTime(val);
                        CalculateAge();
                    }
                }
            }
            catch { /* DOB not critical for edit load */ }
        }

        // ─────────────────────────────────────────────────
        //  UPDATE DONOR
        // ─────────────────────────────────────────────────
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_editingId < 0) return;

            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                cmbBloodType.SelectedIndex == -1)
            {
                MessageBox.Show("Full Name and Blood Type are required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    string query = @"
                        UPDATE Donors SET
                            FullName         = @name,
                            FatherName       = @father,
                            Gender           = @gender,
                            DOB              = @dob,
                            BloodGroup       = @blood,
                            Phone            = @phone,
                            Email            = @email,
                            City             = @city,
                            Address          = @address,
                            LastDonationDate = @dondate,
                            IsEligible       = @eligible
                        WHERE DonorID = @id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name",
                        txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@father",
                        string.IsNullOrWhiteSpace(txtFather.Text)
                            ? (object)DBNull.Value : txtFather.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender",
                        cmbGender.SelectedIndex >= 0
                            ? cmbGender.SelectedItem.ToString()
                            : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@dob", dtpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@blood", cmbBloodType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@phone",
                        string.IsNullOrWhiteSpace(txtPhone.Text)
                            ? (object)DBNull.Value : txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@email",
                        string.IsNullOrWhiteSpace(txtEmail.Text)
                            ? (object)DBNull.Value : txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@city",
                        string.IsNullOrWhiteSpace(txtCity.Text)
                            ? (object)DBNull.Value : txtCity.Text.Trim());
                    cmd.Parameters.AddWithValue("@address",
                        string.IsNullOrWhiteSpace(txtAddress.Text)
                            ? (object)DBNull.Value : txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@dondate", dtpDonDate.Value.Date);
                    cmd.Parameters.AddWithValue("@eligible", chkEligible.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@id", _editingId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Donor updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadDonors();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating donor: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────
        //  DELETE
        // ─────────────────────────────────────────────────
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDonors.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a donor to delete.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Delete this donor?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes) return;

            try
            {
                int id = Convert.ToInt32(
                    dgvDonors.SelectedRows[0].Cells["DonorID"].Value);

                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Donors WHERE DonorID=@id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Donor deleted.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadDonors();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting donor: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────
        //  SEARCH
        // ─────────────────────────────────────────────────
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDonors(txtSearch.Text.Trim());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadDonors();
        }

        // ─────────────────────────────────────────────────
        //  CANCEL EDIT
        // ─────────────────────────────────────────────────
        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // ─────────────────────────────────────────────────
        //  CLEAR FIELDS
        // ─────────────────────────────────────────────────
        private void ClearFields()
        {
            _editingId = -1;
            txtName.Clear();
            txtFather.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtCity.Clear();
            txtAddress.Clear();
            txtAge.Clear();
            cmbGender.SelectedIndex = -1;
            cmbBloodType.SelectedIndex = -1;
            dtpDOB.Value = DateTime.Now.AddYears(-20);
            dtpDonDate.Value = DateTime.Now;
            chkEligible.Checked = true;

            btnAdd.Visible = true;
            btnEdit.Visible = false;
            btnCancelEdit.Visible = false;
        }
    }
}