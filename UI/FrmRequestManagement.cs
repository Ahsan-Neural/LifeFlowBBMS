using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using LifeFlowBBMS.DAL;

namespace LifeFlowBBMS.UI
{
    public partial class FrmRequestManagement : Form
    {
        private int _selectedRequestId = -1;

        public FrmRequestManagement()
        {
            InitializeComponent();
        }

        private void FrmRequestManagement_Load(object sender, EventArgs e)
        {
            StyleGrid();
            LoadRequests();
        }

        // ─────────────────────────────────────────────────
        //  STYLE GRID
        // ─────────────────────────────────────────────────
        private void StyleGrid()
        {
            dgvRequests.EnableHeadersVisualStyles = false;
            dgvRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.Maroon;
            dgvRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRequests.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvRequests.DefaultCellStyle.SelectionBackColor = Color.Firebrick;
            dgvRequests.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        // ─────────────────────────────────────────────────
        //  LOAD REQUESTS
        // ─────────────────────────────────────────────────
        private void LoadRequests(string search = "", string status = "All")
        {
            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    string query = @"SELECT RequestID, PatientName, BloodGroup,
                                     Units, Hospital, ContactNo,
                                     Status, RequestDate, Notes
                                     FROM BloodRequests WHERE 1=1";

                    if (!string.IsNullOrWhiteSpace(search))
                        query += " AND (PatientName LIKE @search " +
                                 "OR BloodGroup LIKE @search " +
                                 "OR Hospital LIKE @search)";

                    if (status != "All")
                        query += " AND Status = @status";

                    query += " ORDER BY RequestDate DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    if (!string.IsNullOrWhiteSpace(search))
                        da.SelectCommand.Parameters.AddWithValue(
                            "@search", "%" + search + "%");
                    if (status != "All")
                        da.SelectCommand.Parameters.AddWithValue("@status", status);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvRequests.DataSource = dt;

                    if (dgvRequests.Columns.Count > 0)
                    {
                        dgvRequests.Columns["RequestID"].HeaderText = "ID";
                        dgvRequests.Columns["RequestID"].Width = 50;
                        dgvRequests.Columns["PatientName"].HeaderText = "Patient Name";
                        dgvRequests.Columns["PatientName"].Width = 160;
                        dgvRequests.Columns["BloodGroup"].HeaderText = "Blood Group";
                        dgvRequests.Columns["BloodGroup"].Width = 100;
                        dgvRequests.Columns["Units"].HeaderText = "Units";
                        dgvRequests.Columns["Units"].Width = 70;
                        dgvRequests.Columns["Hospital"].HeaderText = "Hospital";
                        dgvRequests.Columns["Hospital"].Width = 180;
                        dgvRequests.Columns["ContactNo"].HeaderText = "Contact";
                        dgvRequests.Columns["ContactNo"].Width = 130;
                        dgvRequests.Columns["Status"].HeaderText = "Status";
                        dgvRequests.Columns["Status"].Width = 100;
                        dgvRequests.Columns["RequestDate"].HeaderText = "Request Date";
                        dgvRequests.Columns["RequestDate"].Width = 140;
                        dgvRequests.Columns["RequestDate"]
                            .DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
                        dgvRequests.Columns["Notes"].HeaderText = "Notes";
                        dgvRequests.Columns["Notes"].Width = 180;
                    }

                    foreach (DataGridViewRow row in dgvRequests.Rows)
                    {
                        string s = row.Cells["Status"].Value?.ToString();
                        if (s == "Approved")
                            row.DefaultCellStyle.BackColor =
                                Color.FromArgb(220, 255, 220);
                        else if (s == "Rejected")
                            row.DefaultCellStyle.BackColor =
                                Color.FromArgb(255, 220, 220);
                        else
                            row.DefaultCellStyle.BackColor =
                                Color.FromArgb(255, 255, 210);
                    }

                    UpdateTotalLabel(dt);
                    _selectedRequestId = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading requests: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────
        //  TOTAL LABEL
        // ─────────────────────────────────────────────────
        private void UpdateTotalLabel(DataTable dt)
        {
            int total = dt.Rows.Count,
                pending = 0, approved = 0, rejected = 0;

            foreach (DataRow row in dt.Rows)
            {
                string s = row["Status"].ToString();
                if (s == "Pending") pending++;
                else if (s == "Approved") approved++;
                else if (s == "Rejected") rejected++;
            }

            lblTotal.Text = $"Total: {total}   " +
                            $"Pending: {pending}   " +
                            $"Approved: {approved}   " +
                            $"Rejected: {rejected}";
        }

        // ─────────────────────────────────────────────────
        //  GRID CLICK
        // ─────────────────────────────────────────────────
        private void dgvRequests_CellClick(object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                _selectedRequestId = Convert.ToInt32(
                    dgvRequests.Rows[e.RowIndex].Cells["RequestID"].Value);
        }

        // ─────────────────────────────────────────────────
        //  SEARCH
        // ─────────────────────────────────────────────────
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRequests(txtSearch.Text.Trim(),
                cmbStatusFilter.SelectedItem?.ToString() ?? "All");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbStatusFilter.SelectedIndex = 0;
            LoadRequests();
        }

        // ─────────────────────────────────────────────────
        //  ADD
        // ─────────────────────────────────────────────────
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddEditRequest frm = new FrmAddEditRequest();
            if (frm.ShowDialog() == DialogResult.OK)
                LoadRequests();
        }

        // ─────────────────────────────────────────────────
        //  EDIT
        // ─────────────────────────────────────────────────
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedRequestId == -1)
            {
                MessageBox.Show("Please select a request to edit.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FrmAddEditRequest frm =
                new FrmAddEditRequest(_selectedRequestId);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadRequests();
        }

        // ─────────────────────────────────────────────────
        //  DELETE
        // ─────────────────────────────────────────────────
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedRequestId == -1)
            {
                MessageBox.Show("Please select a request to delete.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Delete this request?", "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = ConnectionManager.GetConnection())
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(
                            "DELETE FROM BloodRequests WHERE RequestID = @id",
                            con);
                        cmd.Parameters.AddWithValue("@id", _selectedRequestId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Request deleted.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRequests();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ─────────────────────────────────────────────────
        //  APPROVE BUTTON
        // ─────────────────────────────────────────────────
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (_selectedRequestId == -1)
            {
                MessageBox.Show("Please select a request first.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get request details from selected row
            string bg = "";
            int units = 0;

            foreach (DataGridViewRow row in dgvRequests.Rows)
            {
                if (Convert.ToInt32(row.Cells["RequestID"].Value)
                    == _selectedRequestId)
                {
                    bg = row.Cells["BloodGroup"].Value?.ToString();
                    units = Convert.ToInt32(row.Cells["Units"].Value);
                    string currentStatus =
                        row.Cells["Status"].Value?.ToString();

                    if (currentStatus == "Approved")
                    {
                        MessageBox.Show(
                            "This request is already approved.",
                            "Info", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }
                    break;
                }
            }

            // Check stock
            int stock = 0;
            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    SqlCommand chk = new SqlCommand(
                        "SELECT ISNULL(Units,0) FROM BloodInventory " +
                        "WHERE BloodGroup = @bg", con);
                    chk.Parameters.AddWithValue("@bg", bg);
                    object val = chk.ExecuteScalar();
                    stock = val != null ? Convert.ToInt32(val) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stock check error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (units > stock)
            {
                MessageBox.Show(
                    $"Cannot approve.\n" +
                    $"Requested: {units} units of {bg}\n" +
                    $"Available: {stock} units",
                    "Insufficient Stock",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                $"Approve request?\n" +
                $"Blood Group : {bg}\n" +
                $"Units       : {units}\n" +
                $"Stock after : {stock - units}",
                "Confirm Approve",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // Approve + deduct + log — all in one transaction
            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    SqlTransaction tr = con.BeginTransaction();
                    try
                    {
                        // 1. Mark Approved
                        SqlCommand upd = new SqlCommand(@"
                            UPDATE BloodRequests
                            SET    Status = 'Approved'
                            WHERE  RequestID = @id", con, tr);
                        upd.Parameters.AddWithValue("@id",
                            _selectedRequestId);
                        upd.ExecuteNonQuery();

                        // 2. Deduct inventory
                        SqlCommand inv = new SqlCommand(@"
                            UPDATE BloodInventory
                            SET    Units       = Units - @units,
                                   LastUpdated = GETDATE()
                            WHERE  BloodGroup  = @bg", con, tr);
                        inv.Parameters.AddWithValue("@units", units);
                        inv.Parameters.AddWithValue("@bg", bg);
                        inv.ExecuteNonQuery();

                        // 3. Log transaction
                        SqlCommand log = new SqlCommand(@"
                            INSERT INTO BloodTransactions
                                (RefType, RefID, BloodGroup, Units,
                                 TransactionDate, Remarks)
                            VALUES
                                ('REQUEST', @refId, @bg, @units,
                                 GETDATE(), 'Request Approved')",
                            con, tr);
                        log.Parameters.AddWithValue("@refId",
                            _selectedRequestId);
                        log.Parameters.AddWithValue("@bg", bg);
                        log.Parameters.AddWithValue("@units", units);
                        log.ExecuteNonQuery();

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }

                MessageBox.Show(
                    $"Request approved!\n{units} units of {bg} deducted from inventory.",
                    "Approved", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Approval error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────
        //  REJECT BUTTON
        // ─────────────────────────────────────────────────
        private void btnReject_Click(object sender, EventArgs e)
        {
            if (_selectedRequestId == -1)
            {
                MessageBox.Show("Please select a request first.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Block re-rejection
            foreach (DataGridViewRow row in dgvRequests.Rows)
            {
                if (Convert.ToInt32(row.Cells["RequestID"].Value)
                    == _selectedRequestId)
                {
                    if (row.Cells["Status"].Value?.ToString() == "Rejected")
                    {
                        MessageBox.Show("This request is already rejected.",
                            "Info", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }
                    break;
                }
            }

            if (MessageBox.Show("Mark this request as Rejected?", "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
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

                MessageBox.Show("Request rejected.", "Rejected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────
        //  REFRESH
        // ─────────────────────────────────────────────────
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbStatusFilter.SelectedIndex = 0;
            LoadRequests();
        }
    }
}