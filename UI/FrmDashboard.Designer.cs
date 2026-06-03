namespace LifeFlowBBMS.UI
{
    partial class FrmDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnNavLogout = new System.Windows.Forms.Button();
            this.btnNavUsers = new System.Windows.Forms.Button();
            this.btnNavReports = new System.Windows.Forms.Button();
            this.btnNavRequests = new System.Windows.Forms.Button();
            this.btnNavInventory = new System.Windows.Forms.Button();
            this.btnNavDonors = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblCard1Title = new System.Windows.Forms.Label();
            this.lblTotalDonors = new System.Windows.Forms.Label();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblCard2Title = new System.Windows.Forms.Label();
            this.lblTotalUnits = new System.Windows.Forms.Label();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblCard3Title = new System.Windows.Forms.Label();
            this.lblLowStock = new System.Windows.Forms.Label();
            this.pieChart = new LiveCharts.WinForms.PieChart();
            this.barChart = new LiveCharts.WinForms.CartesianChart();
            this.lblPieTitle = new System.Windows.Forms.Label();
            this.lblBarTitle = new System.Windows.Forms.Label();

            this.pnlTop.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.SuspendLayout();

            // ── pnlTop ──────────────────────────────────────
            this.pnlTop.BackColor = System.Drawing.Color.Firebrick;
            this.pnlTop.Controls.Add(this.lblWelcome);
            this.pnlTop.Controls.Add(this.lblAppTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(1200, 65);

            // lblAppTitle
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(20, 16);
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Text = "LifeFlow Blood Bank Management System";

            // lblWelcome
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(870, 20);
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Text = "Welcome, User";

            // ── pnlSidebar ──────────────────────────────────
            this.pnlSidebar.BackColor = System.Drawing.Color.Maroon;
            this.pnlSidebar.Controls.Add(this.btnNavLogout);
            this.pnlSidebar.Controls.Add(this.btnNavUsers);
            this.pnlSidebar.Controls.Add(this.btnNavReports);
            this.pnlSidebar.Controls.Add(this.btnNavRequests);
            this.pnlSidebar.Controls.Add(this.btnNavInventory);
            this.pnlSidebar.Controls.Add(this.btnNavDonors);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width = 200;

            // btnNavDonors
            this.btnNavDonors.Text = "  Donor Management";
            this.btnNavDonors.Location = new System.Drawing.Point(0, 0);
            this.btnNavDonors.Size = new System.Drawing.Size(200, 55);
            this.btnNavDonors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDonors.FlatAppearance.BorderSize = 0;
            this.btnNavDonors.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.btnNavDonors.BackColor = System.Drawing.Color.Maroon;
            this.btnNavDonors.ForeColor = System.Drawing.Color.White;
            this.btnNavDonors.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavDonors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDonors.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNavDonors.Click += new System.EventHandler(this.btnNavDonors_Click);

            // btnNavInventory
            this.btnNavInventory.Text = "  Blood Inventory";
            this.btnNavInventory.Location = new System.Drawing.Point(0, 55);
            this.btnNavInventory.Size = new System.Drawing.Size(200, 55);
            this.btnNavInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavInventory.FlatAppearance.BorderSize = 0;
            this.btnNavInventory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.btnNavInventory.BackColor = System.Drawing.Color.Maroon;
            this.btnNavInventory.ForeColor = System.Drawing.Color.White;
            this.btnNavInventory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavInventory.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNavInventory.Click += new System.EventHandler(this.btnNavInventory_Click);

            // btnNavRequests
            this.btnNavRequests.Text = "  Request Management";
            this.btnNavRequests.Location = new System.Drawing.Point(0, 110);
            this.btnNavRequests.Size = new System.Drawing.Size(200, 55);
            this.btnNavRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavRequests.FlatAppearance.BorderSize = 0;
            this.btnNavRequests.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.btnNavRequests.BackColor = System.Drawing.Color.Maroon;
            this.btnNavRequests.ForeColor = System.Drawing.Color.White;
            this.btnNavRequests.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavRequests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavRequests.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNavRequests.Click += new System.EventHandler(this.btnNavRequests_Click);

            // btnNavReports
            this.btnNavReports.Text = "  Reports";
            this.btnNavReports.Location = new System.Drawing.Point(0, 165);
            this.btnNavReports.Size = new System.Drawing.Size(200, 55);
            this.btnNavReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavReports.FlatAppearance.BorderSize = 0;
            this.btnNavReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.btnNavReports.BackColor = System.Drawing.Color.Maroon;
            this.btnNavReports.ForeColor = System.Drawing.Color.White;
            this.btnNavReports.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavReports.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNavReports.Click += new System.EventHandler(this.btnNavReports_Click);

            // btnNavUsers
            this.btnNavUsers.Text = "  User Management";
            this.btnNavUsers.Location = new System.Drawing.Point(0, 220);
            this.btnNavUsers.Size = new System.Drawing.Size(200, 55);
            this.btnNavUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavUsers.FlatAppearance.BorderSize = 0;
            this.btnNavUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.btnNavUsers.BackColor = System.Drawing.Color.Maroon;
            this.btnNavUsers.ForeColor = System.Drawing.Color.White;
            this.btnNavUsers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavUsers.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNavUsers.Click += new System.EventHandler(this.btnNavUsers_Click);

            // btnNavLogout — bottom of sidebar using Anchor
            this.btnNavLogout.Text = "  Logout";
            this.btnNavLogout.Size = new System.Drawing.Size(200, 55);
            this.btnNavLogout.Location = new System.Drawing.Point(0, 580);
            this.btnNavLogout.Anchor = System.Windows.Forms.AnchorStyles.Bottom
                                     | System.Windows.Forms.AnchorStyles.Left
                                     | System.Windows.Forms.AnchorStyles.Right;
            this.btnNavLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavLogout.FlatAppearance.BorderSize = 0;
            this.btnNavLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(180, 0, 0);
            this.btnNavLogout.BackColor = System.Drawing.Color.DarkRed;
            this.btnNavLogout.ForeColor = System.Drawing.Color.White;
            this.btnNavLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavLogout.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNavLogout.Click += new System.EventHandler(this.btnNavLogout_Click);

            // ── pnlContent ──────────────────────────────────
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Controls.Add(this.lblBarTitle);
            this.pnlContent.Controls.Add(this.lblPieTitle);
            this.pnlContent.Controls.Add(this.barChart);
            this.pnlContent.Controls.Add(this.pieChart);
            this.pnlContent.Controls.Add(this.pnlStats);

            // pnlStats
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.pnlStats.Location = new System.Drawing.Point(15, 15);
            this.pnlStats.Size = new System.Drawing.Size(970, 140);
            this.pnlStats.Controls.Add(this.pnlCard1);
            this.pnlStats.Controls.Add(this.pnlCard2);
            this.pnlStats.Controls.Add(this.pnlCard3);

            // pnlCard1
            this.pnlCard1.BackColor = System.Drawing.Color.Firebrick;
            this.pnlCard1.Location = new System.Drawing.Point(0, 0);
            this.pnlCard1.Size = new System.Drawing.Size(305, 135);
            this.pnlCard1.Controls.Add(this.lblCard1Title);
            this.pnlCard1.Controls.Add(this.lblTotalDonors);

            this.lblCard1Title.Text = "TOTAL DONORS";
            this.lblCard1Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCard1Title.ForeColor = System.Drawing.Color.FromArgb(255, 200, 200);
            this.lblCard1Title.Location = new System.Drawing.Point(18, 12);
            this.lblCard1Title.AutoSize = true;

            this.lblTotalDonors.Text = "0";
            this.lblTotalDonors.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Bold);
            this.lblTotalDonors.ForeColor = System.Drawing.Color.White;
            this.lblTotalDonors.Location = new System.Drawing.Point(15, 35);
            this.lblTotalDonors.AutoSize = true;

            // pnlCard2
            this.pnlCard2.BackColor = System.Drawing.Color.Maroon;
            this.pnlCard2.Location = new System.Drawing.Point(330, 0);
            this.pnlCard2.Size = new System.Drawing.Size(305, 135);
            this.pnlCard2.Controls.Add(this.lblCard2Title);
            this.pnlCard2.Controls.Add(this.lblTotalUnits);

            this.lblCard2Title.Text = "TOTAL BLOOD UNITS";
            this.lblCard2Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCard2Title.ForeColor = System.Drawing.Color.FromArgb(255, 200, 200);
            this.lblCard2Title.Location = new System.Drawing.Point(18, 12);
            this.lblCard2Title.AutoSize = true;

            this.lblTotalUnits.Text = "0";
            this.lblTotalUnits.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Bold);
            this.lblTotalUnits.ForeColor = System.Drawing.Color.White;
            this.lblTotalUnits.Location = new System.Drawing.Point(15, 35);
            this.lblTotalUnits.AutoSize = true;

            // pnlCard3
            this.pnlCard3.BackColor = System.Drawing.Color.DarkRed;
            this.pnlCard3.Location = new System.Drawing.Point(660, 0);
            this.pnlCard3.Size = new System.Drawing.Size(305, 135);
            this.pnlCard3.Controls.Add(this.lblCard3Title);
            this.pnlCard3.Controls.Add(this.lblLowStock);

            this.lblCard3Title.Text = "LOW STOCK ALERTS";
            this.lblCard3Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCard3Title.ForeColor = System.Drawing.Color.FromArgb(255, 200, 200);
            this.lblCard3Title.Location = new System.Drawing.Point(18, 12);
            this.lblCard3Title.AutoSize = true;

            this.lblLowStock.Text = "0";
            this.lblLowStock.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Bold);
            this.lblLowStock.ForeColor = System.Drawing.Color.White;
            this.lblLowStock.Location = new System.Drawing.Point(15, 35);
            this.lblLowStock.AutoSize = true;

            // lblPieTitle
            this.lblPieTitle.Text = "Blood Inventory by Type";
            this.lblPieTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPieTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lblPieTitle.Location = new System.Drawing.Point(15, 168);
            this.lblPieTitle.AutoSize = true;

            // pieChart
            this.pieChart.Location = new System.Drawing.Point(15, 195);
            this.pieChart.Size = new System.Drawing.Size(460, 450);
            this.pieChart.BackColor = System.Drawing.Color.White;

            // lblBarTitle
            this.lblBarTitle.Text = "Donors by Blood Group";
            this.lblBarTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBarTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lblBarTitle.Location = new System.Drawing.Point(490, 168);
            this.lblBarTitle.AutoSize = true;

            // barChart
            this.barChart.Location = new System.Drawing.Point(490, 195);
            this.barChart.Size = new System.Drawing.Size(490, 450);
            this.barChart.BackColor = System.Drawing.Color.White;

            // ── FrmDashboard ────────────────────────────────
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlTop);
            this.Text = "LifeFlow BBMS - Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Load += new System.EventHandler(this.FrmDashboard_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnNavDonors;
        private System.Windows.Forms.Button btnNavInventory;
        private System.Windows.Forms.Button btnNavRequests;
        private System.Windows.Forms.Button btnNavReports;
        private System.Windows.Forms.Button btnNavUsers;
        private System.Windows.Forms.Button btnNavLogout;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblCard1Title;
        private System.Windows.Forms.Label lblTotalDonors;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblCard2Title;
        private System.Windows.Forms.Label lblTotalUnits;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblCard3Title;
        private System.Windows.Forms.Label lblLowStock;
        private LiveCharts.WinForms.PieChart pieChart;
        private LiveCharts.WinForms.CartesianChart barChart;
        private System.Windows.Forms.Label lblPieTitle;
        private System.Windows.Forms.Label lblBarTitle;
    }
}