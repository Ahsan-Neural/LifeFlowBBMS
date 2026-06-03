namespace LifeFlowBBMS.UI
{
    partial class FrmBloodRequests
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
            this.lblPatient = new System.Windows.Forms.Label();
            this.txtPatient = new System.Windows.Forms.TextBox();
            this.lblBloodGroup = new System.Windows.Forms.Label();
            this.cmbBloodGroup = new System.Windows.Forms.ComboBox();
            this.lblUnits = new System.Windows.Forms.Label();
            this.txtUnits = new System.Windows.Forms.TextBox();
            this.lblHospital = new System.Windows.Forms.Label();
            this.txtHospital = new System.Windows.Forms.TextBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.dgvRequests = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.Firebrick;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(1000, 55);

            this.lblTitle.Text = "Blood Request Management";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F,
                System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.AutoSize = true;

            // pnlForm
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlForm.Size = new System.Drawing.Size(1000, 120);
            this.pnlForm.Controls.Add(this.lblPatient);
            this.pnlForm.Controls.Add(this.txtPatient);
            this.pnlForm.Controls.Add(this.lblBloodGroup);
            this.pnlForm.Controls.Add(this.cmbBloodGroup);
            this.pnlForm.Controls.Add(this.lblUnits);
            this.pnlForm.Controls.Add(this.txtUnits);
            this.pnlForm.Controls.Add(this.lblHospital);
            this.pnlForm.Controls.Add(this.txtHospital);
            this.pnlForm.Controls.Add(this.lblContact);
            this.pnlForm.Controls.Add(this.txtContact);
            this.pnlForm.Controls.Add(this.lblNotes);
            this.pnlForm.Controls.Add(this.txtNotes);
            this.pnlForm.Controls.Add(this.btnSubmit);
            this.pnlForm.Controls.Add(this.btnApprove);
            this.pnlForm.Controls.Add(this.btnReject);
            this.pnlForm.Controls.Add(this.btnCancelEdit);

            int y1 = 10, y1i = 28;

            this.lblPatient.Text = "Patient Name *";
            this.lblPatient.Location = new System.Drawing.Point(10, y1);
            this.lblPatient.AutoSize = true;
            this.lblPatient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPatient.Location = new System.Drawing.Point(10, y1i);
            this.txtPatient.Size = new System.Drawing.Size(150, 26);
            this.txtPatient.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.lblBloodGroup.Text = "Blood Group *";
            this.lblBloodGroup.Location = new System.Drawing.Point(175, y1);
            this.lblBloodGroup.AutoSize = true;
            this.lblBloodGroup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbBloodGroup.Location = new System.Drawing.Point(175, y1i);
            this.cmbBloodGroup.Size = new System.Drawing.Size(90, 26);
            this.cmbBloodGroup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbBloodGroup.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBloodGroup.Items.AddRange(new object[] {
                "A+","A-","B+","B-","AB+","AB-","O+","O-" });

            this.lblUnits.Text = "Units *";
            this.lblUnits.Location = new System.Drawing.Point(280, y1);
            this.lblUnits.AutoSize = true;
            this.lblUnits.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUnits.Location = new System.Drawing.Point(280, y1i);
            this.txtUnits.Size = new System.Drawing.Size(70, 26);
            this.txtUnits.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.lblHospital.Text = "Hospital *";
            this.lblHospital.Location = new System.Drawing.Point(365, y1);
            this.lblHospital.AutoSize = true;
            this.lblHospital.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHospital.Location = new System.Drawing.Point(365, y1i);
            this.txtHospital.Size = new System.Drawing.Size(170, 26);
            this.txtHospital.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.lblContact.Text = "Contact No";
            this.lblContact.Location = new System.Drawing.Point(550, y1);
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtContact.Location = new System.Drawing.Point(550, y1i);
            this.txtContact.Size = new System.Drawing.Size(130, 26);
            this.txtContact.Font = new System.Drawing.Font("Segoe UI", 9F);

            int y2 = 65, y2i = 83;

            this.lblNotes.Text = "Notes";
            this.lblNotes.Location = new System.Drawing.Point(10, y2);
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotes.Location = new System.Drawing.Point(10, y2i);
            this.txtNotes.Size = new System.Drawing.Size(380, 26);
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.btnSubmit.Text = "+ Submit Request";
            this.btnSubmit.Location = new System.Drawing.Point(410, y2i - 2);
            this.btnSubmit.Size = new System.Drawing.Size(145, 30);
            this.btnSubmit.BackColor = System.Drawing.Color.Firebrick;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            this.btnApprove.Text = "Approve";
            this.btnApprove.Location = new System.Drawing.Point(565, y2i - 2);
            this.btnApprove.Size = new System.Drawing.Size(100, 30);
            this.btnApprove.BackColor = System.Drawing.Color.DarkGreen;
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.FlatAppearance.BorderSize = 0;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);
            this.btnApprove.Visible = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);

            this.btnReject.Text = "Reject";
            this.btnReject.Location = new System.Drawing.Point(675, y2i - 2);
            this.btnReject.Size = new System.Drawing.Size(90, 30);
            this.btnReject.BackColor = System.Drawing.Color.DarkRed;
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.FlatAppearance.BorderSize = 0;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);
            this.btnReject.Visible = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);

            this.btnCancelEdit.Text = "Cancel";
            this.btnCancelEdit.Location = new System.Drawing.Point(775, y2i - 2);
            this.btnCancelEdit.Size = new System.Drawing.Size(80, 30);
            this.btnCancelEdit.BackColor = System.Drawing.Color.Gray;
            this.btnCancelEdit.ForeColor = System.Drawing.Color.White;
            this.btnCancelEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelEdit.FlatAppearance.BorderSize = 0;
            this.btnCancelEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelEdit.Visible = false;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);

            // pnlSearch
            this.pnlSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Size = new System.Drawing.Size(1000, 50);
            this.pnlSearch.Controls.Add(this.lblFilter);
            this.pnlSearch.Controls.Add(this.cmbFilter);
            this.pnlSearch.Controls.Add(this.btnFilter);
            this.pnlSearch.Controls.Add(this.btnShowAll);

            this.lblFilter.Text = "Filter by Status:";
            this.lblFilter.Location = new System.Drawing.Point(15, 15);
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.cmbFilter.Location = new System.Drawing.Point(120, 12);
            this.cmbFilter.Size = new System.Drawing.Size(140, 26);
            this.cmbFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFilter.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.Items.AddRange(new object[] {
                "Pending", "Approved", "Rejected" });

            this.btnFilter.Text = "Filter";
            this.btnFilter.Location = new System.Drawing.Point(275, 10);
            this.btnFilter.Size = new System.Drawing.Size(90, 30);
            this.btnFilter.BackColor = System.Drawing.Color.Maroon;
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);

            this.btnShowAll.Text = "Show All";
            this.btnShowAll.Location = new System.Drawing.Point(375, 10);
            this.btnShowAll.Size = new System.Drawing.Size(90, 30);
            this.btnShowAll.BackColor = System.Drawing.Color.Gray;
            this.btnShowAll.ForeColor = System.Drawing.Color.White;
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.FlatAppearance.BorderSize = 0;
            this.btnShowAll.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);

            // dgvRequests
            this.dgvRequests.Location = new System.Drawing.Point(0, 225);
            this.dgvRequests.Size = new System.Drawing.Size(1000, 385);
            this.dgvRequests.Anchor = System.Windows.Forms.AnchorStyles.Top
                                      | System.Windows.Forms.AnchorStyles.Bottom
                                      | System.Windows.Forms.AnchorStyles.Left
                                      | System.Windows.Forms.AnchorStyles.Right;
            this.dgvRequests.BackgroundColor = System.Drawing.Color.White;
            this.dgvRequests.BorderStyle =
                System.Windows.Forms.BorderStyle.None;
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.MultiSelect = false;
            this.dgvRequests.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvRequests.ScrollBars =
                System.Windows.Forms.ScrollBars.Both;
            this.dgvRequests.RowHeadersVisible = false;
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.Font =
                new System.Drawing.Font("Segoe UI", 9F);
            this.dgvRequests.RowTemplate.Height = 34;
            this.dgvRequests.ColumnHeadersHeight = 38;
            this.dgvRequests.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvRequests_CellClick);

            // Form
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.dgvRequests);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlTop);
            this.Text = "Blood Request Management";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Load += new System.EventHandler(this.FrmBloodRequests_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.TextBox txtPatient;
        private System.Windows.Forms.Label lblBloodGroup;
        private System.Windows.Forms.ComboBox cmbBloodGroup;
        private System.Windows.Forms.Label lblUnits;
        private System.Windows.Forms.TextBox txtUnits;
        private System.Windows.Forms.Label lblHospital;
        private System.Windows.Forms.TextBox txtHospital;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.DataGridView dgvRequests;
    }
}