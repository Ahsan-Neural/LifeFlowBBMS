namespace LifeFlowBBMS.UI
{
    partial class FrmDonorManagement
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
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblFather = new System.Windows.Forms.Label();
            this.txtFather = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblDOB = new System.Windows.Forms.Label();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lblBlood = new System.Windows.Forms.Label();
            this.cmbBloodType = new System.Windows.Forms.ComboBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblDonDate = new System.Windows.Forms.Label();
            this.dtpDonDate = new System.Windows.Forms.DateTimePicker();
            this.chkEligible = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvDonors = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();

            this.pnlTop.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonors)).BeginInit();
            this.SuspendLayout();

            // ── pnlTop ──────────────────────────────────────────────
            this.pnlTop.BackColor = System.Drawing.Color.Firebrick;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(1000, 55);

            this.lblTitle.Text = "Donor Management";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.AutoSize = true;

            // ── pnlForm ──────────────────────────────────────────────
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlForm.Size = new System.Drawing.Size(1000, 145);
            this.pnlForm.Controls.Add(this.lblName);
            this.pnlForm.Controls.Add(this.txtName);
            this.pnlForm.Controls.Add(this.lblFather);
            this.pnlForm.Controls.Add(this.txtFather);
            this.pnlForm.Controls.Add(this.lblGender);
            this.pnlForm.Controls.Add(this.cmbGender);
            this.pnlForm.Controls.Add(this.lblDOB);
            this.pnlForm.Controls.Add(this.dtpDOB);
            this.pnlForm.Controls.Add(this.lblAge);
            this.pnlForm.Controls.Add(this.txtAge);
            this.pnlForm.Controls.Add(this.lblBlood);
            this.pnlForm.Controls.Add(this.cmbBloodType);
            this.pnlForm.Controls.Add(this.lblPhone);
            this.pnlForm.Controls.Add(this.txtPhone);
            this.pnlForm.Controls.Add(this.lblEmail);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Controls.Add(this.lblCity);
            this.pnlForm.Controls.Add(this.txtCity);
            this.pnlForm.Controls.Add(this.lblAddress);
            this.pnlForm.Controls.Add(this.txtAddress);
            this.pnlForm.Controls.Add(this.lblDonDate);
            this.pnlForm.Controls.Add(this.dtpDonDate);
            this.pnlForm.Controls.Add(this.chkEligible);
            this.pnlForm.Controls.Add(this.btnAdd);
            this.pnlForm.Controls.Add(this.btnEdit);
            this.pnlForm.Controls.Add(this.btnCancelEdit);

            // ── ROW 1 (y=10 label, y=28 input) ──────────────────────
            int y1 = 10, y1i = 28;

            // Full Name
            this.lblName.Text = "Full Name *";
            this.lblName.Location = new System.Drawing.Point(10, y1);
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.Location = new System.Drawing.Point(10, y1i);
            this.txtName.Size = new System.Drawing.Size(130, 26);
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);

            // Father Name
            this.lblFather.Text = "Father Name";
            this.lblFather.Location = new System.Drawing.Point(155, y1);
            this.lblFather.AutoSize = true;
            this.lblFather.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFather.Location = new System.Drawing.Point(155, y1i);
            this.txtFather.Size = new System.Drawing.Size(130, 26);
            this.txtFather.Font = new System.Drawing.Font("Segoe UI", 9F);

            // Gender
            this.lblGender.Text = "Gender";
            this.lblGender.Location = new System.Drawing.Point(300, y1);
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbGender.Location = new System.Drawing.Point(300, y1i);
            this.cmbGender.Size = new System.Drawing.Size(90, 26);
            this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.Items.AddRange(new object[] { "Male", "Female", "Other" });

            // Date of Birth
            this.lblDOB.Text = "Date of Birth";
            this.lblDOB.Location = new System.Drawing.Point(405, y1);
            this.lblDOB.AutoSize = true;
            this.lblDOB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDOB.Location = new System.Drawing.Point(405, y1i);
            this.dtpDOB.Size = new System.Drawing.Size(125, 26);
            this.dtpDOB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDOB.Value = System.DateTime.Now.AddYears(-20);

            // Age (read-only)
            this.lblAge.Text = "Age";
            this.lblAge.Location = new System.Drawing.Point(545, y1);
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAge.Location = new System.Drawing.Point(545, y1i);
            this.txtAge.Size = new System.Drawing.Size(50, 26);
            this.txtAge.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAge.ReadOnly = true;
            this.txtAge.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // Blood Type
            this.lblBlood.Text = "Blood Type *";
            this.lblBlood.Location = new System.Drawing.Point(610, y1);
            this.lblBlood.AutoSize = true;
            this.lblBlood.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbBloodType.Location = new System.Drawing.Point(610, y1i);
            this.cmbBloodType.Size = new System.Drawing.Size(85, 26);
            this.cmbBloodType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbBloodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBloodType.Items.AddRange(new object[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" });

            // Phone
            this.lblPhone.Text = "Phone";
            this.lblPhone.Location = new System.Drawing.Point(710, y1);
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhone.Location = new System.Drawing.Point(710, y1i);
            this.txtPhone.Size = new System.Drawing.Size(130, 26);
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9F);

            // ── ROW 2 (y=65 label, y=83 input) ──────────────────────
            int y2 = 65, y2i = 83;

            // Email
            this.lblEmail.Text = "Email";
            this.lblEmail.Location = new System.Drawing.Point(10, y2);
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.Location = new System.Drawing.Point(10, y2i);
            this.txtEmail.Size = new System.Drawing.Size(130, 26);
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);

            // City
            this.lblCity.Text = "City";
            this.lblCity.Location = new System.Drawing.Point(155, y2);
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCity.Location = new System.Drawing.Point(155, y2i);
            this.txtCity.Size = new System.Drawing.Size(130, 26);
            this.txtCity.Font = new System.Drawing.Font("Segoe UI", 9F);

            // Address
            this.lblAddress.Text = "Address";
            this.lblAddress.Location = new System.Drawing.Point(300, y2);
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddress.Location = new System.Drawing.Point(300, y2i);
            this.txtAddress.Size = new System.Drawing.Size(195, 26);
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9F);

            // Last Donation Date
            this.lblDonDate.Text = "Last Donation Date";
            this.lblDonDate.Location = new System.Drawing.Point(510, y2);
            this.lblDonDate.AutoSize = true;
            this.lblDonDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDonDate.Location = new System.Drawing.Point(510, y2i);
            this.dtpDonDate.Size = new System.Drawing.Size(125, 26);
            this.dtpDonDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDonDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDonDate.Value = System.DateTime.Now;

            // Eligible checkbox — well separated from buttons
            this.chkEligible.Text = "Eligible";
            this.chkEligible.Location = new System.Drawing.Point(650, y2i + 3);
            this.chkEligible.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chkEligible.ForeColor = System.Drawing.Color.DarkGreen;
            this.chkEligible.Checked = true;
            this.chkEligible.AutoSize = true;

            // btnAdd — starts at 730 giving 80px gap from checkbox
            this.btnAdd.Text = "+ Add";
            this.btnAdd.Location = new System.Drawing.Point(730, y2i - 2);
            this.btnAdd.Size = new System.Drawing.Size(85, 30);
            this.btnAdd.BackColor = System.Drawing.Color.Firebrick;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.Text = "✎ Update";
            this.btnEdit.Location = new System.Drawing.Point(825, y2i - 2);
            this.btnEdit.Size = new System.Drawing.Size(85, 30);
            this.btnEdit.BackColor = System.Drawing.Color.Maroon;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnCancelEdit
            this.btnCancelEdit.Text = "✕ Cancel";
            this.btnCancelEdit.Location = new System.Drawing.Point(920, y2i - 2);
            this.btnCancelEdit.Size = new System.Drawing.Size(75, 30);
            this.btnCancelEdit.BackColor = System.Drawing.Color.Gray;
            this.btnCancelEdit.ForeColor = System.Drawing.Color.White;
            this.btnCancelEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelEdit.FlatAppearance.BorderSize = 0;
            this.btnCancelEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelEdit.Visible = false;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);

            // ── pnlSearch ────────────────────────────────────────────
            this.pnlSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Size = new System.Drawing.Size(1000, 50);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.btnClear);

            this.lblSearch.Text = "Search:";
            this.lblSearch.Location = new System.Drawing.Point(15, 15);
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.txtSearch.Location = new System.Drawing.Point(65, 12);
            this.txtSearch.Size = new System.Drawing.Size(220, 26);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.btnSearch.Text = "Search";
            this.btnSearch.Location = new System.Drawing.Point(300, 10);
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.BackColor = System.Drawing.Color.Maroon;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            this.btnClear.Text = "Clear";
            this.btnClear.Location = new System.Drawing.Point(410, 10);
            this.btnClear.Size = new System.Drawing.Size(90, 30);
            this.btnClear.BackColor = System.Drawing.Color.Gray;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // ── dgvDonors — scrollable both ways ─────────────────────
            this.dgvDonors.Location = new System.Drawing.Point(0, 250);
            this.dgvDonors.Size = new System.Drawing.Size(1000, 355);
            this.dgvDonors.Anchor = System.Windows.Forms.AnchorStyles.Top
                                  | System.Windows.Forms.AnchorStyles.Bottom
                                  | System.Windows.Forms.AnchorStyles.Left
                                  | System.Windows.Forms.AnchorStyles.Right;
            this.dgvDonors.BackgroundColor = System.Drawing.Color.White;
            this.dgvDonors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDonors.ReadOnly = true;
            this.dgvDonors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDonors.MultiSelect = false;
            // ↓ KEY: disable fill + enable both scrollbars
            this.dgvDonors.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvDonors.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dgvDonors.RowHeadersVisible = false;
            this.dgvDonors.AllowUserToAddRows = false;
            this.dgvDonors.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvDonors.RowTemplate.Height = 34;
            this.dgvDonors.ColumnHeadersHeight = 38;
            this.dgvDonors.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvDonors_CellClick);

            // ── btnDelete ─────────────────────────────────────────────
            this.btnDelete.Text = "✕  Delete Selected Donor";
            this.btnDelete.Location = new System.Drawing.Point(0, 610);
            this.btnDelete.Size = new System.Drawing.Size(1000, 40);
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom
                                  | System.Windows.Forms.AnchorStyles.Left
                                  | System.Windows.Forms.AnchorStyles.Right;
            this.btnDelete.BackColor = System.Drawing.Color.DarkRed;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // ── FrmDonorManagement ────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvDonors);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlTop);
            this.Text = "Donor Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Load += new System.EventHandler(this.FrmDonorManagement_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonors)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Field declarations ─────────────────────────────────────────
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblFather;
        private System.Windows.Forms.TextBox txtFather;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblBlood;
        private System.Windows.Forms.ComboBox cmbBloodType;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblDonDate;
        private System.Windows.Forms.DateTimePicker dtpDonDate;
        private System.Windows.Forms.CheckBox chkEligible;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvDonors;
        private System.Windows.Forms.Button btnDelete;
    }
}