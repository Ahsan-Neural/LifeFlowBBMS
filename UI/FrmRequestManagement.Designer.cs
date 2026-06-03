namespace LifeFlowBBMS.UI
{
    partial class FrmRequestManagement
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblLegend = new System.Windows.Forms.Label();

            this.pnlTop.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.Firebrick;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(1100, 60);
            this.pnlTop.Controls.Add(this.lblTitle);

            // lblTitle
            this.lblTitle.Text = "Request Management";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 14);
            this.lblTitle.AutoSize = true;

            // pnlSearch
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Size = new System.Drawing.Size(1100, 55);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.cmbStatusFilter);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.btnClear);

            // lblSearch
            this.lblSearch.Text = "Search:";
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSearch.Location = new System.Drawing.Point(15, 17);
            this.lblSearch.AutoSize = true;

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(75, 14);
            this.txtSearch.Size = new System.Drawing.Size(220, 26);

            // cmbStatusFilter
            this.cmbStatusFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatusFilter.Location = new System.Drawing.Point(310, 14);
            this.cmbStatusFilter.Size = new System.Drawing.Size(130, 26);
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.Items.AddRange(new object[] {
                "All", "Pending", "Approved", "Rejected" });
            this.cmbStatusFilter.SelectedIndex = 0;

            // btnSearch
            this.btnSearch.Text = "Search";
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSearch.Location = new System.Drawing.Point(455, 12);
            this.btnSearch.Size = new System.Drawing.Size(90, 32);
            this.btnSearch.BackColor = System.Drawing.Color.Firebrick;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnClear
            this.btnClear.Text = "Clear";
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClear.Location = new System.Drawing.Point(555, 12);
            this.btnClear.Size = new System.Drawing.Size(80, 32);
            this.btnClear.BackColor = System.Drawing.Color.Gray;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // pnlButtons
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Size = new System.Drawing.Size(1100, 55);
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnApprove);
            this.pnlButtons.Controls.Add(this.btnReject);
            this.pnlButtons.Controls.Add(this.btnRefresh);

            // btnAdd
            this.btnAdd.Text = "+ Add Request";
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(15, 11);
            this.btnAdd.Size = new System.Drawing.Size(130, 34);
            this.btnAdd.BackColor = System.Drawing.Color.Firebrick;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.Text = "✎ Edit";
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEdit.Location = new System.Drawing.Point(158, 11);
            this.btnEdit.Size = new System.Drawing.Size(95, 34);
            this.btnEdit.BackColor = System.Drawing.Color.Maroon;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.Text = "✕ Delete";
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDelete.Location = new System.Drawing.Point(263, 11);
            this.btnDelete.Size = new System.Drawing.Size(100, 34);
            this.btnDelete.BackColor = System.Drawing.Color.DarkRed;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnApprove
            this.btnApprove.Text = "✔ Approve";
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnApprove.Location = new System.Drawing.Point(373, 11);
            this.btnApprove.Size = new System.Drawing.Size(110, 34);
            this.btnApprove.BackColor = System.Drawing.Color.DarkGreen;
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.FlatAppearance.BorderSize = 0;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);

            // btnReject
            this.btnReject.Text = "✖ Reject";
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReject.Location = new System.Drawing.Point(493, 11);
            this.btnReject.Size = new System.Drawing.Size(100, 34);
            this.btnReject.BackColor = System.Drawing.Color.FromArgb(180, 50, 50);
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.FlatAppearance.BorderSize = 0;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);

            // btnRefresh
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRefresh.Location = new System.Drawing.Point(603, 11);
            this.btnRefresh.Size = new System.Drawing.Size(110, 34);
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // dgvRequests
            this.dgvRequests.Location = new System.Drawing.Point(0, 185);
            this.dgvRequests.Size = new System.Drawing.Size(1100, 390);
            this.dgvRequests.Anchor = System.Windows.Forms.AnchorStyles.Top
                                    | System.Windows.Forms.AnchorStyles.Bottom
                                    | System.Windows.Forms.AnchorStyles.Left
                                    | System.Windows.Forms.AnchorStyles.Right;
            this.dgvRequests.BackgroundColor = System.Drawing.Color.White;
            this.dgvRequests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRequests.RowHeadersVisible = false;
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AllowUserToDeleteRows = false;
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.MultiSelect = false;
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequests.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvRequests.RowTemplate.Height = 38;
            this.dgvRequests.ColumnHeadersHeight = 40;
            this.dgvRequests.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequests_CellClick);

            // lblLegend
            this.lblLegend.Text = "🟡 Pending   🟢 Approved   🔴 Rejected";
            this.lblLegend.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLegend.ForeColor = System.Drawing.Color.DimGray;
            this.lblLegend.Location = new System.Drawing.Point(10, 588);
            this.lblLegend.AutoSize = true;
            this.lblLegend.Anchor = System.Windows.Forms.AnchorStyles.Bottom
                                  | System.Windows.Forms.AnchorStyles.Left;

            // lblTotal
            this.lblTotal.Text = "Total: 0   Pending: 0   Approved: 0   Rejected: 0";
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(10, 610);
            this.lblTotal.AutoSize = true;
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom
                                 | System.Windows.Forms.AnchorStyles.Left;

            // FrmRequestManagement
            this.ClientSize = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblLegend);
            this.Controls.Add(this.dgvRequests);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlTop);
            this.Text = "Request Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Load += new System.EventHandler(this.FrmRequestManagement_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Label lblLegend;
        private System.Windows.Forms.Label lblTotal;
    }
}