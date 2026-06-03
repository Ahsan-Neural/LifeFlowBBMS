namespace LifeFlowBBMS.UI
{
    partial class FrmUserManagement
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
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblActive = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.Firebrick;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(900, 55);

            this.lblTitle.Text = "User Management";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F,
                System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.AutoSize = true;

            // pnlForm
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlForm.Size = new System.Drawing.Size(900, 120);
            this.pnlForm.Controls.Add(this.lblFullName);
            this.pnlForm.Controls.Add(this.txtFullName);
            this.pnlForm.Controls.Add(this.lblUsername);
            this.pnlForm.Controls.Add(this.txtUsername);
            this.pnlForm.Controls.Add(this.lblPassword);
            this.pnlForm.Controls.Add(this.txtPassword);
            this.pnlForm.Controls.Add(this.lblRole);
            this.pnlForm.Controls.Add(this.cmbRole);
            this.pnlForm.Controls.Add(this.lblActive);
            this.pnlForm.Controls.Add(this.chkActive);
            this.pnlForm.Controls.Add(this.btnSave);
            this.pnlForm.Controls.Add(this.btnUpdate);
            this.pnlForm.Controls.Add(this.btnDelete);
            this.pnlForm.Controls.Add(this.btnClear);

            int y1 = 10, y1i = 28;

            // FullName
            this.lblFullName.Text = "Full Name *";
            this.lblFullName.Location = new System.Drawing.Point(10, y1);
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFullName.Location = new System.Drawing.Point(10, y1i);
            this.txtFullName.Size = new System.Drawing.Size(160, 26);
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 9F);

            // Username
            this.lblUsername.Text = "Username *";
            this.lblUsername.Location = new System.Drawing.Point(185, y1);
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsername.Location = new System.Drawing.Point(185, y1i);
            this.txtUsername.Size = new System.Drawing.Size(140, 26);
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F);

            // Password
            this.lblPassword.Text = "Password *";
            this.lblPassword.Location = new System.Drawing.Point(340, y1);
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.Location = new System.Drawing.Point(340, y1i);
            this.txtPassword.Size = new System.Drawing.Size(140, 26);
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.PasswordChar = '●';

            // Role
            this.lblRole.Text = "Role *";
            this.lblRole.Location = new System.Drawing.Point(495, y1);
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbRole.Location = new System.Drawing.Point(495, y1i);
            this.cmbRole.Size = new System.Drawing.Size(110, 26);
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Items.AddRange(new object[] { "Admin", "Staff", "User" });

            // Row 2
            int y2 = 65, y2i = 83;

            // Active
            this.lblActive.Text = "Active";
            this.lblActive.Location = new System.Drawing.Point(10, y2);
            this.lblActive.AutoSize = true;
            this.lblActive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkActive.Location = new System.Drawing.Point(10, y2i);
            this.chkActive.Size = new System.Drawing.Size(80, 24);
            this.chkActive.Text = "Is Active";
            this.chkActive.Checked = true;
            this.chkActive.Font = new System.Drawing.Font("Segoe UI", 9F);

            // btnSave
            this.btnSave.Text = "+ Add User";
            this.btnSave.Location = new System.Drawing.Point(110, y2i - 2);
            this.btnSave.Size = new System.Drawing.Size(110, 30);
            this.btnSave.BackColor = System.Drawing.Color.Firebrick;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnUpdate
            this.btnUpdate.Text = "✎ Update";
            this.btnUpdate.Location = new System.Drawing.Point(230, y2i - 2);
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnDelete
            this.btnDelete.Text = "✕ Delete";
            this.btnDelete.Location = new System.Drawing.Point(340, y2i - 2);
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.BackColor = System.Drawing.Color.Maroon;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnClear
            this.btnClear.Text = "Clear";
            this.btnClear.Location = new System.Drawing.Point(450, y2i - 2);
            this.btnClear.Size = new System.Drawing.Size(80, 30);
            this.btnClear.BackColor = System.Drawing.Color.Gray;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // pnlSearch
            this.pnlSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Size = new System.Drawing.Size(900, 50);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.btnShowAll);

            this.lblSearch.Text = "Search:";
            this.lblSearch.Location = new System.Drawing.Point(10, 15);
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.txtSearch.Location = new System.Drawing.Point(65, 12);
            this.txtSearch.Size = new System.Drawing.Size(200, 26);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.btnSearch.Text = "Search";
            this.btnSearch.Location = new System.Drawing.Point(275, 11);
            this.btnSearch.Size = new System.Drawing.Size(85, 28);
            this.btnSearch.BackColor = System.Drawing.Color.Maroon;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            this.btnShowAll.Text = "Show All";
            this.btnShowAll.Location = new System.Drawing.Point(370, 11);
            this.btnShowAll.Size = new System.Drawing.Size(85, 28);
            this.btnShowAll.BackColor = System.Drawing.Color.Gray;
            this.btnShowAll.ForeColor = System.Drawing.Color.White;
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.FlatAppearance.BorderSize = 0;
            this.btnShowAll.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);

            // dgvUsers
            this.dgvUsers.Location = new System.Drawing.Point(0, 225);
            this.dgvUsers.Size = new System.Drawing.Size(900, 385);
            this.dgvUsers.Anchor = System.Windows.Forms.AnchorStyles.Top
                                   | System.Windows.Forms.AnchorStyles.Bottom
                                   | System.Windows.Forms.AnchorStyles.Left
                                   | System.Windows.Forms.AnchorStyles.Right;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvUsers.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.Font =
                new System.Drawing.Font("Segoe UI", 9F);
            this.dgvUsers.RowTemplate.Height = 34;
            this.dgvUsers.ColumnHeadersHeight = 38;
            this.dgvUsers.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvUsers_CellClick);

            // Form
            this.ClientSize = new System.Drawing.Size(900, 640);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlTop);
            this.Text = "User Management";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(900, 640);
            this.Load += new System.EventHandler(this.FrmUserManagement_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.DataGridView dgvUsers;
    }
}