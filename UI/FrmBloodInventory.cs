using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using LifeFlowBBMS.DAL;

namespace LifeFlowBBMS.UI
{
    public partial class FrmBloodInventory : Form
    {
        public FrmBloodInventory()
        {
            InitializeComponent();
        }

        private void FrmBloodInventory_Load(object sender, EventArgs e)
        {
            StyleGrid();
            LoadInventory();
        }

        // ─────────────────────────────────────────────────
        //  STYLE GRID
        // ─────────────────────────────────────────────────
        private void StyleGrid()
        {
            dgvInventory.EnableHeadersVisualStyles = false;
            dgvInventory.ColumnHeadersDefaultCellStyle.BackColor =
                Color.Maroon;
            dgvInventory.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;
            dgvInventory.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvInventory.DefaultCellStyle.SelectionBackColor =
                Color.Firebrick;
            dgvInventory.DefaultCellStyle.SelectionForeColor =
                Color.White;
            dgvInventory.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(255, 245, 245);
        }

        // ─────────────────────────────────────────────────
        //  LOAD INVENTORY
        // ─────────────────────────────────────────────────
        private void LoadInventory()
        {
            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT BloodGroup,
                               Units,
                               CASE
                                   WHEN Units = 0  THEN 'Out of Stock'
                                   WHEN Units < 5  THEN 'Critical'
                                   WHEN Units < 10 THEN 'Low'
                                   ELSE                 'Sufficient'
                               END AS Status,
                               LastUpdated
                        FROM   BloodInventory
                        ORDER  BY BloodGroup";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvInventory.DataSource = dt;

                    if (dgvInventory.Columns.Count > 0)
                    {
                        dgvInventory.Columns["BloodGroup"].HeaderText = "Blood Group";
                        dgvInventory.Columns["BloodGroup"].Width = 130;
                        dgvInventory.Columns["Units"].HeaderText = "Available Units";
                        dgvInventory.Columns["Units"].Width = 150;
                        dgvInventory.Columns["Status"].HeaderText = "Stock Status";
                        dgvInventory.Columns["Status"].Width = 150;
                        dgvInventory.Columns["LastUpdated"].HeaderText = "Last Updated";
                        dgvInventory.Columns["LastUpdated"].Width = 180;
                        dgvInventory.Columns["LastUpdated"]
                            .DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
                    }

                    // Color code rows by status
                    foreach (DataGridViewRow row in dgvInventory.Rows)
                    {
                        string s = row.Cells["Status"].Value?.ToString();
                        if (s == "Out of Stock")
                            row.DefaultCellStyle.ForeColor = Color.DarkRed;
                        else if (s == "Critical")
                            row.DefaultCellStyle.ForeColor = Color.OrangeRed;
                        else if (s == "Low")
                            row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                        else
                            row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    }

                    // Update summary label
                    SqlCommand total = new SqlCommand(
                        "SELECT ISNULL(SUM(Units),0) FROM BloodInventory", con);
                    lblSummary.Text =
                        "Total Units in Stock: " + total.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────
        //  ADD STOCK
        // ─────────────────────────────────────────────────
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbBloodGroup.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtUnits.Text))
            {
                MessageBox.Show("Blood Group and Units are required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtUnits.Text.Trim(), out int units) || units <= 0)
            {
                MessageBox.Show("Units must be a positive number.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string bg = cmbBloodGroup.SelectedItem.ToString();
            string remarks = string.IsNullOrWhiteSpace(txtRemarks.Text)
                             ? "Stock Added" : txtRemarks.Text.Trim();

            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    SqlTransaction tr = con.BeginTransaction();
                    try
                    {
                        // Update inventory
                        SqlCommand upd = new SqlCommand(@"
                            UPDATE BloodInventory
                            SET    Units       = Units + @units,
                                   LastUpdated = GETDATE()
                            WHERE  BloodGroup  = @bg", con, tr);
                        upd.Parameters.AddWithValue("@units", units);
                        upd.Parameters.AddWithValue("@bg", bg);
                        upd.ExecuteNonQuery();

                        // Log transaction
                        SqlCommand log = new SqlCommand(@"
                            INSERT INTO BloodTransactions
                                (RefType, RefID, BloodGroup, Units,
                                 TransactionDate, Remarks)
                            VALUES
                                ('ADD', NULL, @bg, @units, GETDATE(), @remarks)",
                            con, tr);
                        log.Parameters.AddWithValue("@bg", bg);
                        log.Parameters.AddWithValue("@units", units);
                        log.Parameters.AddWithValue("@remarks", remarks);
                        log.ExecuteNonQuery();

                        tr.Commit();
                    }
                    catch { tr.Rollback(); throw; }
                }

                MessageBox.Show(
                    $"{units} units of {bg} added successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding stock: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────
        //  DEDUCT STOCK
        // ─────────────────────────────────────────────────
        private void btnDeduct_Click(object sender, EventArgs e)
        {
            if (cmbBloodGroup.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtUnits.Text))
            {
                MessageBox.Show("Blood Group and Units are required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtUnits.Text.Trim(), out int units) || units <= 0)
            {
                MessageBox.Show("Units must be a positive number.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string bg = cmbBloodGroup.SelectedItem.ToString();
            string remarks = string.IsNullOrWhiteSpace(txtRemarks.Text)
                             ? "Stock Deducted" : txtRemarks.Text.Trim();

            // Check current stock first
            int currentStock = 0;
            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    SqlCommand chk = new SqlCommand(
                        "SELECT Units FROM BloodInventory WHERE BloodGroup = @bg",
                        con);
                    chk.Parameters.AddWithValue("@bg", bg);
                    object val = chk.ExecuteScalar();
                    currentStock = val != null ? Convert.ToInt32(val) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking stock: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (units > currentStock)
            {
                MessageBox.Show(
                    $"Cannot deduct {units} units.\n" +
                    $"Only {currentStock} units of {bg} available.",
                    "Insufficient Stock",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        // Update inventory
                        SqlCommand upd = new SqlCommand(@"
                            UPDATE BloodInventory
                            SET    Units       = Units - @units,
                                   LastUpdated = GETDATE()
                            WHERE  BloodGroup  = @bg", con, tr);
                        upd.Parameters.AddWithValue("@units", units);
                        upd.Parameters.AddWithValue("@bg", bg);
                        upd.ExecuteNonQuery();

                        // Log transaction
                        SqlCommand log = new SqlCommand(@"
                            INSERT INTO BloodTransactions
                                (RefType, RefID, BloodGroup, Units,
                                 TransactionDate, Remarks)
                            VALUES
                                ('DEDUCT', NULL, @bg, @units, GETDATE(), @remarks)",
                            con, tr);
                        log.Parameters.AddWithValue("@bg", bg);
                        log.Parameters.AddWithValue("@units", units);
                        log.Parameters.AddWithValue("@remarks", remarks);
                        log.ExecuteNonQuery();

                        tr.Commit();
                    }
                    catch { tr.Rollback(); throw; }
                }

                MessageBox.Show(
                    $"{units} units of {bg} deducted successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deducting stock: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────
        //  CLEAR FIELDS
        // ─────────────────────────────────────────────────
        private void ClearFields()
        {
            cmbBloodGroup.SelectedIndex = -1;
            txtUnits.Clear();
            txtRemarks.Clear();
        }
    }
}