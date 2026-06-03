namespace LifeFlowBBMS.UI
{
    partial class FrmReports
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDonors = new System.Windows.Forms.TabPage();
            this.tabInventory = new System.Windows.Forms.TabPage();
            this.tabRequests = new System.Windows.Forms.TabPage();
            this.tabTrans = new System.Windows.Forms.TabPage();

            // ── Donors tab controls
            this.pnlDonorFilter = new System.Windows.Forms.Panel();
            this.lblDonorBG = new System.Windows.Forms.Label();
            this.cmbDonorBG = new System.Windows.Forms.ComboBox();
            this.lblDonorCity = new System.Windows.Forms.Label();
            this.txtDonorCity = new System.Windows.Forms.TextBox();
            this.lblDonorElig = new System.Windows.Forms.Label();
            this.cmbDonorElig = new System.Windows.Forms.ComboBox();
            this.btnDonorFilter = new System.Windows.Forms.Button();
            this.btnDonorReset = new System.Windows.Forms.Button();
            this.btnDonorPrint = new System.Windows.Forms.Button();
            this.dgvDonors = new System.Windows.Forms.DataGridView();

            // ── Inventory tab controls
            this.pnlInvTop = new System.Windows.Forms.Panel();
            this.btnInvPrint = new System.Windows.Forms.Button();
            this.lblInvInfo = new System.Windows.Forms.Label();
            this.dgvInventory = new System.Windows.Forms.DataGridView();

            // ── Requests tab controls
            this.pnlReqTop = new System.Windows.Forms.Panel();
            this.lblReqFilter = new System.Windows.Forms.Label();
            this.cmbReqStatus = new System.Windows.Forms.ComboBox();
            this.btnReqFilter = new System.Windows.Forms.Button();
            this.btnReqReset = new System.Windows.Forms.Button();
            this.btnReqPrint = new System.Windows.Forms.Button();
            this.dgvRequests = new System.Windows.Forms.DataGridView();

            // ── Transactions tab controls
            this.pnlTransTop = new System.Windows.Forms.Panel();
            this.lblTransFilter = new System.Windows.Forms.Label();
            this.cmbTransType = new System.Windows.Forms.ComboBox();
            this.btnTransFilter = new System.Windows.Forms.Button();
            this.btnTransReset = new System.Windows.Forms.Button();
            this.btnTransPrint = new System.Windows.Forms.Button();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.SuspendLayout();

            // ── pnlTop ───────────────────────────────────────────────
            this.pnlTop.BackColor = System.Drawing.Color.Firebrick;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(1100, 55);

            this.lblTitle.Text = "Reports";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F,
                System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.AutoSize = true;

            // ── tabControl ───────────────────────────────────────────
            this.tabControl.Location = new System.Drawing.Point(0, 55);
            this.tabControl.Size = new System.Drawing.Size(1100, 595);
            this.tabControl.Anchor = System.Windows.Forms.AnchorStyles.Top
                                      | System.Windows.Forms.AnchorStyles.Bottom
                                      | System.Windows.Forms.AnchorStyles.Left
                                      | System.Windows.Forms.AnchorStyles.Right;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);
            this.tabControl.Controls.Add(this.tabDonors);
            this.tabControl.Controls.Add(this.tabInventory);
            this.tabControl.Controls.Add(this.tabRequests);
            this.tabControl.Controls.Add(this.tabTrans);
            this.tabControl.SelectedIndexChanged +=
                new System.EventHandler(this.tabControl_SelectedIndexChanged);

            // ── TAB: DONORS ──────────────────────────────────────────
            this.tabDonors.Text = "  Donors  ";
            this.tabDonors.BackColor = System.Drawing.Color.White;
            this.tabDonors.Controls.Add(this.dgvDonors);
            this.tabDonors.Controls.Add(this.pnlDonorFilter);

            this.pnlDonorFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlDonorFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDonorFilter.Size = new System.Drawing.Size(1100, 50);
            this.pnlDonorFilter.Controls.Add(this.lblDonorBG);
            this.pnlDonorFilter.Controls.Add(this.cmbDonorBG);
            this.pnlDonorFilter.Controls.Add(this.lblDonorCity);
            this.pnlDonorFilter.Controls.Add(this.txtDonorCity);
            this.pnlDonorFilter.Controls.Add(this.lblDonorElig);
            this.pnlDonorFilter.Controls.Add(this.cmbDonorElig);
            this.pnlDonorFilter.Controls.Add(this.btnDonorFilter);
            this.pnlDonorFilter.Controls.Add(this.btnDonorReset);
            this.pnlDonorFilter.Controls.Add(this.btnDonorPrint);

            this.lblDonorBG.Text = "Blood Group:";
            this.lblDonorBG.Location = new System.Drawing.Point(10, 15);
            this.lblDonorBG.AutoSize = true;
            this.lblDonorBG.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.cmbDonorBG.Location = new System.Drawing.Point(95, 12);
            this.cmbDonorBG.Size = new System.Drawing.Size(90, 26);
            this.cmbDonorBG.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbDonorBG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDonorBG.Items.Add("All");
            this.cmbDonorBG.Items.AddRange(new object[] {
                "A+","A-","B+","B-","AB+","AB-","O+","O-" });
            this.cmbDonorBG.SelectedIndex = 0;

            this.lblDonorCity.Text = "City:";
            this.lblDonorCity.Location = new System.Drawing.Point(200, 15);
            this.lblDonorCity.AutoSize = true;
            this.lblDonorCity.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.txtDonorCity.Location = new System.Drawing.Point(235, 12);
            this.txtDonorCity.Size = new System.Drawing.Size(130, 26);
            this.txtDonorCity.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.lblDonorElig.Text = "Eligible:";
            this.lblDonorElig.Location = new System.Drawing.Point(380, 15);
            this.lblDonorElig.AutoSize = true;
            this.lblDonorElig.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.cmbDonorElig.Location = new System.Drawing.Point(435, 12);
            this.cmbDonorElig.Size = new System.Drawing.Size(90, 26);
            this.cmbDonorElig.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbDonorElig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDonorElig.Items.AddRange(new object[] { "All", "Yes", "No" });
            this.cmbDonorElig.SelectedIndex = 0;

            this.btnDonorFilter.Text = "Filter";
            this.btnDonorFilter.Location = new System.Drawing.Point(540, 11);
            this.btnDonorFilter.Size = new System.Drawing.Size(85, 28);
            this.btnDonorFilter.BackColor = System.Drawing.Color.Maroon;
            this.btnDonorFilter.ForeColor = System.Drawing.Color.White;
            this.btnDonorFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonorFilter.FlatAppearance.BorderSize = 0;
            this.btnDonorFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDonorFilter.Click += new System.EventHandler(this.btnDonorFilter_Click);

            this.btnDonorReset.Text = "Reset";
            this.btnDonorReset.Location = new System.Drawing.Point(635, 11);
            this.btnDonorReset.Size = new System.Drawing.Size(75, 28);
            this.btnDonorReset.BackColor = System.Drawing.Color.Gray;
            this.btnDonorReset.ForeColor = System.Drawing.Color.White;
            this.btnDonorReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonorReset.FlatAppearance.BorderSize = 0;
            this.btnDonorReset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDonorReset.Click += new System.EventHandler(this.btnDonorReset_Click);

            this.btnDonorPrint.Text = "Print";
            this.btnDonorPrint.Location = new System.Drawing.Point(720, 11);
            this.btnDonorPrint.Size = new System.Drawing.Size(75, 28);
            this.btnDonorPrint.BackColor = System.Drawing.Color.Firebrick;
            this.btnDonorPrint.ForeColor = System.Drawing.Color.White;
            this.btnDonorPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonorPrint.FlatAppearance.BorderSize = 0;
            this.btnDonorPrint.Font = new System.Drawing.Font("Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);
            this.btnDonorPrint.Click += new System.EventHandler(this.btnDonorPrint_Click);

            this.dgvDonors.Location = new System.Drawing.Point(0, 50);
            this.dgvDonors.Size = new System.Drawing.Size(1080, 510);
            this.dgvDonors.Anchor = System.Windows.Forms.AnchorStyles.Top
                                    | System.Windows.Forms.AnchorStyles.Bottom
                                    | System.Windows.Forms.AnchorStyles.Left
                                    | System.Windows.Forms.AnchorStyles.Right;
            this.dgvDonors.BackgroundColor = System.Drawing.Color.White;
            this.dgvDonors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDonors.ReadOnly = true;
            this.dgvDonors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDonors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvDonors.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dgvDonors.RowHeadersVisible = false;
            this.dgvDonors.AllowUserToAddRows = false;
            this.dgvDonors.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvDonors.RowTemplate.Height = 32;
            this.dgvDonors.ColumnHeadersHeight = 36;

            // ── TAB: INVENTORY ───────────────────────────────────────
            this.tabInventory.Text = "  Inventory  ";
            this.tabInventory.BackColor = System.Drawing.Color.White;
            this.tabInventory.Controls.Add(this.dgvInventory);
            this.tabInventory.Controls.Add(this.pnlInvTop);

            this.pnlInvTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlInvTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInvTop.Size = new System.Drawing.Size(1100, 50);
            this.pnlInvTop.Controls.Add(this.lblInvInfo);
            this.pnlInvTop.Controls.Add(this.btnInvPrint);

            this.lblInvInfo.Text = "Current blood stock levels for all groups";
            this.lblInvInfo.Location = new System.Drawing.Point(10, 15);
            this.lblInvInfo.AutoSize = true;
            this.lblInvInfo.Font = new System.Drawing.Font("Segoe UI", 9F,
                System.Drawing.FontStyle.Italic);
            this.lblInvInfo.ForeColor = System.Drawing.Color.Maroon;

            this.btnInvPrint.Text = "Print";
            this.btnInvPrint.Location = new System.Drawing.Point(720, 11);
            this.btnInvPrint.Size = new System.Drawing.Size(75, 28);
            this.btnInvPrint.BackColor = System.Drawing.Color.Firebrick;
            this.btnInvPrint.ForeColor = System.Drawing.Color.White;
            this.btnInvPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvPrint.FlatAppearance.BorderSize = 0;
            this.btnInvPrint.Font = new System.Drawing.Font("Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);
            this.btnInvPrint.Click += new System.EventHandler(this.btnInvPrint_Click);

            this.dgvInventory.Location = new System.Drawing.Point(0, 50);
            this.dgvInventory.Size = new System.Drawing.Size(1080, 510);
            this.dgvInventory.Anchor = System.Windows.Forms.AnchorStyles.Top
                                       | System.Windows.Forms.AnchorStyles.Bottom
                                       | System.Windows.Forms.AnchorStyles.Left
                                       | System.Windows.Forms.AnchorStyles.Right;
            this.dgvInventory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvInventory.RowTemplate.Height = 40;
            this.dgvInventory.ColumnHeadersHeight = 40;

            // ── TAB: REQUESTS ────────────────────────────────────────
            this.tabRequests.Text = "  Blood Requests  ";
            this.tabRequests.BackColor = System.Drawing.Color.White;
            this.tabRequests.Controls.Add(this.dgvRequests);
            this.tabRequests.Controls.Add(this.pnlReqTop);

            this.pnlReqTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlReqTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReqTop.Size = new System.Drawing.Size(1100, 50);
            this.pnlReqTop.Controls.Add(this.lblReqFilter);
            this.pnlReqTop.Controls.Add(this.cmbReqStatus);
            this.pnlReqTop.Controls.Add(this.btnReqFilter);
            this.pnlReqTop.Controls.Add(this.btnReqReset);
            this.pnlReqTop.Controls.Add(this.btnReqPrint);

            this.lblReqFilter.Text = "Filter by Status:";
            this.lblReqFilter.Location = new System.Drawing.Point(10, 15);
            this.lblReqFilter.AutoSize = true;
            this.lblReqFilter.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.cmbReqStatus.Location = new System.Drawing.Point(125, 12);
            this.cmbReqStatus.Size = new System.Drawing.Size(130, 26);
            this.cmbReqStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbReqStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReqStatus.Items.AddRange(new object[] {
                "All", "Pending", "Approved", "Rejected" });
            this.cmbReqStatus.SelectedIndex = 0;

            this.btnReqFilter.Text = "Filter";
            this.btnReqFilter.Location = new System.Drawing.Point(270, 11);
            this.btnReqFilter.Size = new System.Drawing.Size(85, 28);
            this.btnReqFilter.BackColor = System.Drawing.Color.Maroon;
            this.btnReqFilter.ForeColor = System.Drawing.Color.White;
            this.btnReqFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReqFilter.FlatAppearance.BorderSize = 0;
            this.btnReqFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReqFilter.Click += new System.EventHandler(this.btnReqFilter_Click);

            this.btnReqReset.Text = "Reset";
            this.btnReqReset.Location = new System.Drawing.Point(365, 11);
            this.btnReqReset.Size = new System.Drawing.Size(75, 28);
            this.btnReqReset.BackColor = System.Drawing.Color.Gray;
            this.btnReqReset.ForeColor = System.Drawing.Color.White;
            this.btnReqReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReqReset.FlatAppearance.BorderSize = 0;
            this.btnReqReset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReqReset.Click += new System.EventHandler(this.btnReqReset_Click);

            this.btnReqPrint.Text = "Print";
            this.btnReqPrint.Location = new System.Drawing.Point(450, 11);
            this.btnReqPrint.Size = new System.Drawing.Size(75, 28);
            this.btnReqPrint.BackColor = System.Drawing.Color.Firebrick;
            this.btnReqPrint.ForeColor = System.Drawing.Color.White;
            this.btnReqPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReqPrint.FlatAppearance.BorderSize = 0;
            this.btnReqPrint.Font = new System.Drawing.Font("Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);
            this.btnReqPrint.Click += new System.EventHandler(this.btnReqPrint_Click);

            this.dgvRequests.Location = new System.Drawing.Point(0, 50);
            this.dgvRequests.Size = new System.Drawing.Size(1080, 510);
            this.dgvRequests.Anchor = System.Windows.Forms.AnchorStyles.Top
                                      | System.Windows.Forms.AnchorStyles.Bottom
                                      | System.Windows.Forms.AnchorStyles.Left
                                      | System.Windows.Forms.AnchorStyles.Right;
            this.dgvRequests.BackgroundColor = System.Drawing.Color.White;
            this.dgvRequests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvRequests.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dgvRequests.RowHeadersVisible = false;
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvRequests.RowTemplate.Height = 32;
            this.dgvRequests.ColumnHeadersHeight = 36;

            // ── TAB: TRANSACTIONS ────────────────────────────────────
            this.tabTrans.Text = "  Transactions  ";
            this.tabTrans.BackColor = System.Drawing.Color.White;
            this.tabTrans.Controls.Add(this.dgvTransactions);
            this.tabTrans.Controls.Add(this.pnlTransTop);

            this.pnlTransTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTransTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTransTop.Size = new System.Drawing.Size(1100, 50);
            this.pnlTransTop.Controls.Add(this.lblTransFilter);
            this.pnlTransTop.Controls.Add(this.cmbTransType);
            this.pnlTransTop.Controls.Add(this.btnTransFilter);
            this.pnlTransTop.Controls.Add(this.btnTransReset);
            this.pnlTransTop.Controls.Add(this.btnTransPrint);

            this.lblTransFilter.Text = "Filter by Type:";
            this.lblTransFilter.Location = new System.Drawing.Point(10, 15);
            this.lblTransFilter.AutoSize = true;
            this.lblTransFilter.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.cmbTransType.Location = new System.Drawing.Point(115, 12);
            this.cmbTransType.Size = new System.Drawing.Size(130, 26);
            this.cmbTransType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransType.Items.AddRange(new object[] {
                "All", "ADD", "DEDUCT", "REQUEST" });
            this.cmbTransType.SelectedIndex = 0;

            this.btnTransFilter.Text = "Filter";
            this.btnTransFilter.Location = new System.Drawing.Point(260, 11);
            this.btnTransFilter.Size = new System.Drawing.Size(85, 28);
            this.btnTransFilter.BackColor = System.Drawing.Color.Maroon;
            this.btnTransFilter.ForeColor = System.Drawing.Color.White;
            this.btnTransFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransFilter.FlatAppearance.BorderSize = 0;
            this.btnTransFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTransFilter.Click += new System.EventHandler(this.btnTransFilter_Click);

            this.btnTransReset.Text = "Reset";
            this.btnTransReset.Location = new System.Drawing.Point(355, 11);
            this.btnTransReset.Size = new System.Drawing.Size(75, 28);
            this.btnTransReset.BackColor = System.Drawing.Color.Gray;
            this.btnTransReset.ForeColor = System.Drawing.Color.White;
            this.btnTransReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransReset.FlatAppearance.BorderSize = 0;
            this.btnTransReset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTransReset.Click += new System.EventHandler(this.btnTransReset_Click);

            this.btnTransPrint.Text = "Print";
            this.btnTransPrint.Location = new System.Drawing.Point(440, 11);
            this.btnTransPrint.Size = new System.Drawing.Size(75, 28);
            this.btnTransPrint.BackColor = System.Drawing.Color.Firebrick;
            this.btnTransPrint.ForeColor = System.Drawing.Color.White;
            this.btnTransPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransPrint.FlatAppearance.BorderSize = 0;
            this.btnTransPrint.Font = new System.Drawing.Font("Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);
            this.btnTransPrint.Click += new System.EventHandler(this.btnTransPrint_Click);

            this.dgvTransactions.Location = new System.Drawing.Point(0, 50);
            this.dgvTransactions.Size = new System.Drawing.Size(1080, 510);
            this.dgvTransactions.Anchor = System.Windows.Forms.AnchorStyles.Top
                                          | System.Windows.Forms.AnchorStyles.Bottom
                                          | System.Windows.Forms.AnchorStyles.Left
                                          | System.Windows.Forms.AnchorStyles.Right;
            this.dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvTransactions.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvTransactions.RowTemplate.Height = 32;
            this.dgvTransactions.ColumnHeadersHeight = 36;

            // ── Form ─────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlTop);
            this.Text = "Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(1100, 650);
            this.Load += new System.EventHandler(this.FrmReports_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Field declarations ────────────────────────────────────────
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabDonors;
        private System.Windows.Forms.TabPage tabInventory;
        private System.Windows.Forms.TabPage tabRequests;
        private System.Windows.Forms.TabPage tabTrans;

        private System.Windows.Forms.Panel pnlDonorFilter;
        private System.Windows.Forms.Label lblDonorBG;
        private System.Windows.Forms.ComboBox cmbDonorBG;
        private System.Windows.Forms.Label lblDonorCity;
        private System.Windows.Forms.TextBox txtDonorCity;
        private System.Windows.Forms.Label lblDonorElig;
        private System.Windows.Forms.ComboBox cmbDonorElig;
        private System.Windows.Forms.Button btnDonorFilter;
        private System.Windows.Forms.Button btnDonorReset;
        private System.Windows.Forms.Button btnDonorPrint;
        private System.Windows.Forms.DataGridView dgvDonors;

        private System.Windows.Forms.Panel pnlInvTop;
        private System.Windows.Forms.Label lblInvInfo;
        private System.Windows.Forms.Button btnInvPrint;
        private System.Windows.Forms.DataGridView dgvInventory;

        private System.Windows.Forms.Panel pnlReqTop;
        private System.Windows.Forms.Label lblReqFilter;
        private System.Windows.Forms.ComboBox cmbReqStatus;
        private System.Windows.Forms.Button btnReqFilter;
        private System.Windows.Forms.Button btnReqReset;
        private System.Windows.Forms.Button btnReqPrint;
        private System.Windows.Forms.DataGridView dgvRequests;

        private System.Windows.Forms.Panel pnlTransTop;
        private System.Windows.Forms.Label lblTransFilter;
        private System.Windows.Forms.ComboBox cmbTransType;
        private System.Windows.Forms.Button btnTransFilter;
        private System.Windows.Forms.Button btnTransReset;
        private System.Windows.Forms.Button btnTransPrint;
        private System.Windows.Forms.DataGridView dgvTransactions;
    }
}