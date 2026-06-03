using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using LifeFlowBBMS.DAL;

namespace LifeFlowBBMS.UI
{
    public partial class FrmBloodRequests : Form
    {
        private int _selectedRequestId = -1;

        public FrmBloodRequests()
        {
            InitializeComponent();
        }

        private void FrmBloodRequests_Load(object sender, EventArgs e)
        {
            StyleGrid();
            LoadRequests();
        }

        private void StyleGrid()
        {
            dgvRequests.EnableHeadersVisualStyles = false;
            dgvRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.Maroon;
            dgvRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRequests.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvRequests.DefaultCellStyle.SelectionBackColor = Color.Firebrick;
            dgvRequests.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvRequests.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(255, 245, 245);
        }

        private void LoadRequests(string statusFilter = "")
        {
            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT RequestID, PatientName, BloodGroup, Units,
                               Hospital, ContactNo, Status, RequestDate, Notes
                        FROM   BloodRequests";

                    if (!string.IsNullOrEmpty(statusFilter))
                        query += " WHERE Status = @status";

                    query += " ORDER BY RequestDate DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    if (!string.IsNullOrEmpty(statusFilter))
                        da.SelectCommand.Parameters.AddWithValue("@status", statusFilter);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvRequests.DataSource = dt;

                    if (dgvRequests.Columns.Count > 0)
                    {
                        dgvRequests.Columns["RequestID"].HeaderText = "ID";
                        dgvRequests.Columns["RequestID"].Width = 50;
                        dgvRequests.Columns["PatientName"].HeaderText = "Patient";
                        dgvRequests.Columns["PatientName"].Width = 160;
                        dgvRequests.Columns["BloodGroup"].HeaderText = "Blood Group";
                        dgvRequests.Columns["BloodGroup"].Width = 95;
                        dgvRequests.Columns["Units"].HeaderText = "Units";
                        dgvRequests.Columns["Units"].Width = 65;
                        dgvRequests.Columns["Hospital"].HeaderText = "Hospital";
                        dgvRequests.Columns["Hospital"].Width = 180;
                        dgvRequests.Columns["ContactNo"].HeaderText = "Contact";
                        dgvRequests.Columns["ContactNo"].Width = 120;
                        dgvRequests.Columns["Status"].HeaderText = "Status";
                        dgvRequests.Columns["Status"].Width = 90;
                        dgvRequests.Columns["RequestDate"].HeaderText = "Date";
                        dgvRequests.Columns["RequestDate"].Width = 130;
                        dgvRequests.Columns["RequestDate"]
                            .DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
                        dgvRequests.Columns["Notes"].HeaderText = "Notes";
                        dgvRequests.Columns["Notes"].Width = 200;
                    }

                    foreach (DataGridViewRow row in dgvRequests.Rows)
                    {
                        string status = row.Cells["Status"].Value?.ToString();
                        if (status == "Approved")
                            row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                        else if (status == "Rejected")
                            row.DefaultCellStyle.ForeColor = Color.DarkRed;
                        else
                            row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading requests: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPatient.Text) ||
                cmbBloodGroup.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtUnits.Text) ||
                string.IsNullOrWhiteSpace(txtHospital.Text))
            {
                MessageBox.Show("Patient Name, Blood Group, Units and Hospital are required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtUnits.Text.Trim(), out int units) || units <= 0)
            {
                MessageBox.Show("Units must be a positive number.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    string query = @"
                        INSERT INTO BloodRequests
                            (PatientName, BloodGroup, Units, Hospital,
                             ContactNo, Status, RequestDate, Notes)
                        VALUES
                            (@patient, @bg, @units, @hospital,
                             @contact, 'Pending', GETDATE(), @notes)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@patient", txtPatient.Text.Trim());
                    cmd.Parameters.AddWithValue("@bg", cmbBloodGroup.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@units", units);
                    cmd.Parameters.AddWithValue("@hospital", txtHospital.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact",
                        string.IsNullOrWhiteSpace(txtContact.Text)
                            ? (object)DBNull.Value : txtContact.Text.Trim());
                    cmd.Parameters.AddWithValue("@notes",
                        string.IsNullOrWhiteSpace(txtNotes.Text)
                            ? (object)DBNull.Value : txtNotes.Text.Trim());
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Blood request submitted successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting request: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRequests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvRequests.Rows[e.RowIndex];
            _selectedRequestId = Convert.ToInt32(row.Cells["RequestID"].Value);
            string status = row.Cells["Status"].Value?.ToString();

            txtPatient.Text = row.Cells["PatientName"].Value?.ToString() ?? "";
            txtHospital.Text = row.Cells["Hospital"].Value?.ToString() ?? "";
            txtContact.Text = row.Cells["ContactNo"].Value?.ToString() ?? "";
            txtNotes.Text = row.Cells["Notes"].Value?.ToString() ?? "";
            txtUnits.Text = row.Cells["Units"].Value?.ToString() ?? "";

            string bg = row.Cells["BloodGroup"].Value?.ToString() ?? "";
            cmbBloodGroup.SelectedIndex = cmbBloodGroup.Items.IndexOf(bg);

            bool isPending = status == "Pending";
            btnSubmit.Visible = false;
            btnApprove.Visible = isPending;
            btnReject.Visible = isPending;
            btnCancelEdit.Visible = true;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (_selectedRequestId < 0) return;

            string bg = cmbBloodGroup.SelectedItem?.ToString();
            int unitsNeeded = int.TryParse(txtUnits.Text, out int u) ? u : 0;

            int currentStock = 0;
            using (SqlConnection con = ConnectionManager.GetConnection())
            {
                con.Open();
                SqlCommand chk = new SqlCommand(
                    "SELECT Units FROM BloodInventory WHERE BloodGroup=@bg", con);
                chk.Parameters.AddWithValue("@bg", bg);
                object val = chk.ExecuteScalar();
                currentStock = val != null ? Convert.ToInt32(val) : 0;
            }

            if (unitsNeeded > currentStock)
            {
                MessageBox.Show(
                    $"Cannot approve. Only {currentStock} units of {bg} available.",
                    "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    SqlTransaction tr = con.BeginTransaction();
                    try
                    {
                        SqlCommand upd = new SqlCommand(@"
                            UPDATE BloodRequests
                            SET    Status = 'Approved'
                            WHERE  RequestID = @id", con, tr);
                        upd.Parameters.AddWithValue("@id", _selectedRequestId);
                        upd.ExecuteNonQuery();

                        SqlCommand inv = new SqlCommand(@"
                            UPDATE BloodInventory
                            SET    Units = Units - @units,
                                   LastUpdated = GETDATE()
                            WHERE  BloodGroup = @bg", con, tr);
                        inv.Parameters.AddWithValue("@units", unitsNeeded);
                        inv.Parameters.AddWithValue("@bg", bg);
                        inv.ExecuteNonQuery();

                        SqlCommand log = new SqlCommand(@"
                            INSERT INTO BloodTransactions
                                (RefType, RefID, BloodGroup, Units, TransactionDate, Remarks)
                            VALUES
                                ('REQUEST', @refId, @bg, @units, GETDATE(), 'Request Approved')",
                            con, tr);
                        log.Parameters.AddWithValue("@refId", _selectedRequestId);
                        log.Parameters.AddWithValue("@bg", bg);
                        log.Parameters.AddWithValue("@units", unitsNeeded);
                        log.ExecuteNonQuery();

                        tr.Commit();
                    }
                    catch { tr.Rollback(); throw; }
                }

                MessageBox.Show("Request approved and inventory updated!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error approving request: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (_selectedRequestId < 0) return;

            if (MessageBox.Show("Reject this blood request?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"
                        UPDATE BloodRequests
                        SET    Status = 'Rejected'
                        WHERE  RequestID = @id", con);
                    cmd.Parameters.AddWithValue("@id", _selectedRequestId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Request rejected.", "Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error rejecting request: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedIndex >= 0)
                LoadRequests(cmbFilter.SelectedItem.ToString());
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            cmbFilter.SelectedIndex = -1;
            LoadRequests();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            _selectedRequestId = -1;
            txtPatient.Clear();
            txtHospital.Clear();
            txtContact.Clear();
            txtNotes.Clear();
            txtUnits.Clear();
            cmbBloodGroup.SelectedIndex = -1;
            btnSubmit.Visible = true;
            btnApprove.Visible = false;
            btnReject.Visible = false;
            btnCancelEdit.Visible = false;
        }
    }
}