using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using LifeFlowBBMS.DAL;

namespace LifeFlowBBMS.UI
{
    public partial class FrmReports : Form
    {
        // Holds the grid to print whichever tab is active
        private DataGridView _activePrintGrid = null;
        private string _activePrintTitle = "";

        public FrmReports()
        {
            InitializeComponent();
        }

        private void FrmReports_Load(object sender, EventArgs e)
        {
            StyleGrid(dgvDonors);
            StyleGrid(dgvInventory);
            StyleGrid(dgvRequests);
            StyleGrid(dgvTransactions);
            LoadDonors();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0: LoadDonors(); break;
                case 1: LoadInventory(); break;
                case 2: LoadRequests(); break;
                case 3: LoadTransactions(); break;
            }
        }

        // ─────────────────────────────────────────────────
        //  STYLE GRID
        // ─────────────────────────────────────────────────
        private void StyleGrid(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Maroon;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.DefaultCellStyle.SelectionBackColor = Color.Firebrick;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(255, 245, 245);
        }

        // ─────────────────────────────────────────────────
        //  TAB 1 — DONORS
        // ─────────────────────────────────────────────────
        private void LoadDonors(string bg = "", string city = "", string elig = "")
        {
            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT DonorID, FullName, FatherName, Gender,
                               BloodGroup, Phone, Email, City,
                               LastDonationDate,
                               CASE WHEN IsEligible=1 THEN 'Yes' ELSE 'No' END AS Eligible
                        FROM   Donors
                        WHERE  1=1";

                    if (!string.IsNullOrEmpty(bg) && bg != "All")
                        query += " AND BloodGroup = @bg";
                    if (!string.IsNullOrEmpty(city))
                        query += " AND City LIKE @city";
                    if (!string.IsNullOrEmpty(elig) && elig != "All")
                        query += " AND IsEligible = @elig";

                    query += " ORDER BY FullName";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    if (!string.IsNullOrEmpty(bg) && bg != "All")
                        da.SelectCommand.Parameters.AddWithValue("@bg", bg);
                    if (!string.IsNullOrEmpty(city))
                        da.SelectCommand.Parameters.AddWithValue("@city", "%" + city + "%");
                    if (!string.IsNullOrEmpty(elig) && elig != "All")
                        da.SelectCommand.Parameters.AddWithValue("@elig",
                            elig == "Yes" ? 1 : 0);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDonors.DataSource = dt;

                    if (dgvDonors.Columns.Count > 0)
                    {
                        dgvDonors.Columns["DonorID"].Width = 50;
                        dgvDonors.Columns["FullName"].Width = 150;
                        dgvDonors.Columns["FatherName"].Width = 130;
                        dgvDonors.Columns["Gender"].Width = 70;
                        dgvDonors.Columns["BloodGroup"].Width = 90;
                        dgvDonors.Columns["Phone"].Width = 130;
                        dgvDonors.Columns["Email"].Width = 180;
                        dgvDonors.Columns["City"].Width = 110;
                        dgvDonors.Columns["LastDonationDate"].Width = 120;
                        dgvDonors.Columns["LastDonationDate"]
                            .DefaultCellStyle.Format = "dd/MM/yyyy";
                        dgvDonors.Columns["Eligible"].Width = 70;

                        dgvDonors.Columns["DonorID"].HeaderText = "ID";
                        dgvDonors.Columns["FullName"].HeaderText = "Full Name";
                        dgvDonors.Columns["FatherName"].HeaderText = "Father Name";
                        dgvDonors.Columns["BloodGroup"].HeaderText = "Blood Group";
                        dgvDonors.Columns["LastDonationDate"].HeaderText = "Last Donation";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDonorFilter_Click(object sender, EventArgs e)
        {
            LoadDonors(
                cmbDonorBG.SelectedItem?.ToString() ?? "All",
                txtDonorCity.Text.Trim(),
                cmbDonorElig.SelectedItem?.ToString() ?? "All");
        }

        private void btnDonorReset_Click(object sender, EventArgs e)
        {
            cmbDonorBG.SelectedIndex = 0;
            txtDonorCity.Clear();
            cmbDonorElig.SelectedIndex = 0;
            LoadDonors();
        }

        private void btnDonorPrint_Click(object sender, EventArgs e)
        {
            _activePrintGrid = dgvDonors;
            _activePrintTitle = "Donors Report — LifeFlow BBMS";
            PrintGrid();
        }

        // ─────────────────────────────────────────────────
        //  TAB 2 — INVENTORY
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
                                   ELSE 'Sufficient'
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
                        dgvInventory.Columns["Units"].HeaderText = "Available Units";
                        dgvInventory.Columns["Status"].HeaderText = "Stock Status";
                        dgvInventory.Columns["LastUpdated"].HeaderText = "Last Updated";
                        dgvInventory.Columns["LastUpdated"]
                            .DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
                    }

                    foreach (DataGridViewRow row in dgvInventory.Rows)
                    {
                        string s = row.Cells["Status"].Value?.ToString();
                        if (s == "Out of Stock") row.DefaultCellStyle.ForeColor = Color.DarkRed;
                        else if (s == "Critical") row.DefaultCellStyle.ForeColor = Color.OrangeRed;
                        else if (s == "Low") row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                        else row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInvPrint_Click(object sender, EventArgs e)
        {
            _activePrintGrid = dgvInventory;
            _activePrintTitle = "Blood Inventory Report — LifeFlow BBMS";
            PrintGrid();
        }

        // ─────────────────────────────────────────────────
        //  TAB 3 — REQUESTS
        // ─────────────────────────────────────────────────
        private void LoadRequests(string status = "")
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

                    if (!string.IsNullOrEmpty(status) && status != "All")
                        query += " WHERE Status = @status";

                    query += " ORDER BY RequestDate DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    if (!string.IsNullOrEmpty(status) && status != "All")
                        da.SelectCommand.Parameters.AddWithValue("@status", status);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvRequests.DataSource = dt;

                    if (dgvRequests.Columns.Count > 0)
                    {
                        dgvRequests.Columns["RequestID"].Width = 50;
                        dgvRequests.Columns["PatientName"].Width = 150;
                        dgvRequests.Columns["BloodGroup"].Width = 90;
                        dgvRequests.Columns["Units"].Width = 65;
                        dgvRequests.Columns["Hospital"].Width = 180;
                        dgvRequests.Columns["ContactNo"].Width = 120;
                        dgvRequests.Columns["Status"].Width = 90;
                        dgvRequests.Columns["RequestDate"].Width = 130;
                        dgvRequests.Columns["RequestDate"]
                            .DefaultCellStyle.Format = "dd/MM/yyyy";
                        dgvRequests.Columns["Notes"].Width = 180;

                        dgvRequests.Columns["RequestID"].HeaderText = "ID";
                        dgvRequests.Columns["PatientName"].HeaderText = "Patient";
                        dgvRequests.Columns["BloodGroup"].HeaderText = "Blood Group";
                        dgvRequests.Columns["ContactNo"].HeaderText = "Contact";
                        dgvRequests.Columns["RequestDate"].HeaderText = "Date";
                    }

                    foreach (DataGridViewRow row in dgvRequests.Rows)
                    {
                        string s = row.Cells["Status"].Value?.ToString();
                        if (s == "Approved") row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                        else if (s == "Rejected") row.DefaultCellStyle.ForeColor = Color.DarkRed;
                        else row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReqFilter_Click(object sender, EventArgs e)
        {
            LoadRequests(cmbReqStatus.SelectedItem?.ToString() ?? "All");
        }

        private void btnReqReset_Click(object sender, EventArgs e)
        {
            cmbReqStatus.SelectedIndex = 0;
            LoadRequests();
        }

        private void btnReqPrint_Click(object sender, EventArgs e)
        {
            _activePrintGrid = dgvRequests;
            _activePrintTitle = "Blood Requests Report — LifeFlow BBMS";
            PrintGrid();
        }

        // ─────────────────────────────────────────────────
        //  TAB 4 — TRANSACTIONS
        // ─────────────────────────────────────────────────
        private void LoadTransactions(string type = "")
        {
            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT TransactionID, RefType, BloodGroup,
                               Units, TransactionDate, Remarks
                        FROM   BloodTransactions";

                    if (!string.IsNullOrEmpty(type) && type != "All")
                        query += " WHERE RefType = @type";

                    query += " ORDER BY TransactionDate DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    if (!string.IsNullOrEmpty(type) && type != "All")
                        da.SelectCommand.Parameters.AddWithValue("@type", type);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvTransactions.DataSource = dt;

                    if (dgvTransactions.Columns.Count > 0)
                    {
                        dgvTransactions.Columns["TransactionID"].Width = 50;
                        dgvTransactions.Columns["RefType"].Width = 100;
                        dgvTransactions.Columns["BloodGroup"].Width = 100;
                        dgvTransactions.Columns["Units"].Width = 80;
                        dgvTransactions.Columns["TransactionDate"].Width = 150;
                        dgvTransactions.Columns["TransactionDate"]
                            .DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
                        dgvTransactions.Columns["Remarks"].Width = 300;

                        dgvTransactions.Columns["TransactionID"].HeaderText = "ID";
                        dgvTransactions.Columns["RefType"].HeaderText = "Type";
                        dgvTransactions.Columns["BloodGroup"].HeaderText = "Blood Group";
                        dgvTransactions.Columns["TransactionDate"].HeaderText = "Date & Time";
                    }

                    foreach (DataGridViewRow row in dgvTransactions.Rows)
                    {
                        string t = row.Cells["RefType"].Value?.ToString();
                        if (t == "ADD") row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                        else if (t == "DEDUCT") row.DefaultCellStyle.ForeColor = Color.DarkRed;
                        else row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTransFilter_Click(object sender, EventArgs e)
        {
            LoadTransactions(cmbTransType.SelectedItem?.ToString() ?? "All");
        }

        private void btnTransReset_Click(object sender, EventArgs e)
        {
            cmbTransType.SelectedIndex = 0;
            LoadTransactions();
        }

        private void btnTransPrint_Click(object sender, EventArgs e)
        {
            _activePrintGrid = dgvTransactions;
            _activePrintTitle = "Transaction History — LifeFlow BBMS";
            PrintGrid();
        }

        // ─────────────────────────────────────────────────
        //  PRINT — works for any tab
        // ─────────────────────────────────────────────────
        private void PrintGrid()
        {
            if (_activePrintGrid == null ||
                _activePrintGrid.Rows.Count == 0)
            {
                MessageBox.Show("No data to print.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = true;
            pd.DefaultPageSettings.Margins =
                new System.Drawing.Printing.Margins(40, 40, 40, 40);

            int currentRow = 0;

            pd.PrintPage += (s, ev) =>
            {
                Graphics g = ev.Graphics;
                Font fTitle = new Font("Segoe UI", 13F, FontStyle.Bold);
                Font fHead = new Font("Segoe UI", 9F, FontStyle.Bold);
                Font fCell = new Font("Segoe UI", 8F);
                float x = ev.MarginBounds.Left;
                float y = ev.MarginBounds.Top;
                float w = ev.MarginBounds.Width;
                int cols = _activePrintGrid.Columns.Count;
                float colW = w / cols;
                float rowH = 22f;

                // Title
                g.DrawString(_activePrintTitle, fTitle,
                    Brushes.Firebrick, x, y);
                y += 28;

                g.DrawString("Printed: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"),
                    fCell, Brushes.Gray, x, y);
                y += 20;

                // Header row
                g.FillRectangle(new SolidBrush(Color.Maroon),
                    x, y, w, rowH);
                for (int c = 0; c < cols; c++)
                {
                    g.DrawString(
                        _activePrintGrid.Columns[c].HeaderText,
                        fHead, Brushes.White,
                        x + c * colW + 2, y + 4);
                }
                y += rowH;

                // Data rows
                while (currentRow < _activePrintGrid.Rows.Count)
                {
                    if (y + rowH > ev.MarginBounds.Bottom)
                    {
                        ev.HasMorePages = true;
                        return;
                    }

                    Brush bg = (currentRow % 2 == 0)
                        ? Brushes.White
                        : new SolidBrush(Color.FromArgb(255, 245, 245));

                    g.FillRectangle(bg, x, y, w, rowH);

                    for (int c = 0; c < cols; c++)
                    {
                        string val = _activePrintGrid
                            .Rows[currentRow].Cells[c].FormattedValue?.ToString() ?? "";
                        g.DrawString(val, fCell, Brushes.Black,
                            x + c * colW + 2, y + 4);
                    }

                    y += rowH;
                    currentRow++;
                }

                ev.HasMorePages = false;
            };

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.Width = 1100;
            preview.Height = 700;
            preview.ShowDialog();
        }
    }
}