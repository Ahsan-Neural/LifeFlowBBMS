using LifeFlowBBMS.DAL;
using LifeFlowBBMS.UI;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LifeFlowBBMS.UI
{
    public partial class FrmDashboard : Form
    {
        private string _userName;
        private string _role;

        public FrmDashboard(string userName, string role)
        {
            InitializeComponent();
            _userName = userName;
            _role = role;
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, " + _userName + "  |  " + _role;

            if (_role != "Admin")
                btnNavUsers.Visible = false;

            btnNavLogout.Location =
                new System.Drawing.Point(0, pnlSidebar.Height - 55);
            btnNavLogout.BringToFront();

            LoadStats();
            LoadInventoryChart();
            LoadDonorChart();
        }

        // ─────────────────────────────────────────────────
        //  STATS CARDS
        // ─────────────────────────────────────────────────
        private void LoadStats()
        {
            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();

                    // Total Donors
                    SqlCommand cmd =
                        new SqlCommand("SELECT COUNT(*) FROM Donors", con);
                    lblTotalDonors.Text = cmd.ExecuteScalar().ToString();

                    // Total Blood Units
                    cmd = new SqlCommand(
                        "SELECT ISNULL(SUM(Units),0) FROM BloodInventory", con);
                    lblTotalUnits.Text = cmd.ExecuteScalar().ToString();

                    // Low Stock Groups (less than 5 units)
                    cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM BloodInventory WHERE Units < 5", con);
                    lblLowStock.Text = cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stats error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────
        //  PIE CHART — Blood Inventory by Type
        // ─────────────────────────────────────────────────
        private void LoadInventoryChart()
        {
            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        @"SELECT BloodGroup, SUM(Units) AS Units
                          FROM   BloodInventory
                          GROUP  BY BloodGroup
                          ORDER  BY BloodGroup", con);

                    SqlDataReader dr = cmd.ExecuteReader();
                    var seriesCollection = new SeriesCollection();

                    while (dr.Read())
                    {
                        int units = Convert.ToInt32(dr["Units"]);
                        string group = dr["BloodGroup"].ToString();

                        if (units > 0)
                        {
                            seriesCollection.Add(new PieSeries
                            {
                                Title = group,
                                Values = new ChartValues<double> { units },
                                DataLabels = true,
                                LabelPoint = point => $"{group}: {units}"
                            });
                        }
                    }

                    pieChart.Series = seriesCollection;
                    pieChart.LegendLocation = LegendLocation.Right;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pie chart error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────
        //  BAR CHART — Donors by Blood Group
        // ─────────────────────────────────────────────────
        private void LoadDonorChart()
        {
            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        @"SELECT BloodGroup, COUNT(*) AS Total
                          FROM   Donors
                          GROUP  BY BloodGroup
                          ORDER  BY BloodGroup", con);

                    SqlDataReader dr = cmd.ExecuteReader();
                    var labels =
                        new System.Collections.Generic.List<string>();
                    var values = new ChartValues<double>();

                    while (dr.Read())
                    {
                        labels.Add(dr["BloodGroup"].ToString());
                        values.Add(Convert.ToDouble(dr["Total"]));
                    }

                    barChart.Series = new SeriesCollection
                    {
                        new ColumnSeries
                        {
                            Title      = "Donors",
                            Values     = values,
                            DataLabels = true,
                            Fill       = new System.Windows.Media.SolidColorBrush(
                                System.Windows.Media.Color.FromRgb(178, 34, 34))
                        }
                    };

                    barChart.AxisX.Clear();
                    barChart.AxisX.Add(new Axis
                    {
                        Title = "Blood Group",
                        Labels = labels,
                        LabelsRotation = 0,
                        Separator = new Separator { Step = 1 }
                    });

                    barChart.AxisY.Clear();
                    barChart.AxisY.Add(new Axis
                    {
                        Title = "Count",
                        MinValue = 0,
                        Separator = new Separator { Step = 1 }
                    });

                    barChart.LegendLocation = LegendLocation.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bar chart error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────
        //  SIDEBAR NAVIGATION
        // ─────────────────────────────────────────────────
        private void btnNavDonors_Click(object sender, EventArgs e)
        {
            new FrmDonorManagement().ShowDialog();
            LoadStats();
            LoadDonorChart();
        }

        private void btnNavInventory_Click(object sender, EventArgs e)
        {
            new FrmBloodInventory().ShowDialog();
            LoadStats();
            LoadInventoryChart();
        }

        private void btnNavRequests_Click(object sender, EventArgs e)
        {
            new FrmBloodRequests().ShowDialog();
            LoadStats();
        }

        private void btnNavReports_Click(object sender, EventArgs e)
        {
            new FrmReports().ShowDialog();
        }

        private void btnNavUsers_Click(object sender, EventArgs e)
        {
            new FrmUserManagement().ShowDialog();
        }

        private void btnNavLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new FrmLogin().Show();
                this.Close();
            }
        }
    }
}