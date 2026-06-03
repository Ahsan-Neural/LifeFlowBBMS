namespace LifeFlowBBMS.UI
{
    partial class FrmBloodInventory
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
            this.lblBloodGroup = new System.Windows.Forms.Label();
            this.cmbBloodGroup = new System.Windows.Forms.ComboBox();
            this.lblUnits = new System.Windows.Forms.Label();
            this.txtUnits = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDeduct = new System.Windows.Forms.Button();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblSummary = new System.Windows.Forms.Label();

            this.pnlTop.SuspendLayout();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.Firebrick;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(1000, 55);

            this.lblTitle.Text = "Blood Inventory Management";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.AutoSize = true;

            // pnlForm
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlForm.Size = new System.Drawing.Size(1000, 80);
            this.pnlForm.Controls.Add(this.lblBloodGroup);
            this.pnlForm.Controls.Add(this.cmbBloodGroup);
            this.pnlForm.Controls.Add(this.lblUnits);
            this.pnlForm.Controls.Add(this.txtUnits);
            this.pnlForm.Controls.Add(this.lblRemarks);
            this.pnlForm.Controls.Add(this.txtRemarks);
            this.pnlForm.Controls.Add(this.btnAdd);
            this.pnlForm.Controls.Add(this.btnDeduct);

            // Blood Group
            this.lblBloodGroup.Text = "Blood Group";
            this.lblBloodGroup.Location = new System.Drawing.Point(15, 10);
            this.lblBloodGroup.AutoSize = true;
            this.lblBloodGroup.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.cmbBloodGroup.Location = new System.Drawing.Point(15, 28);
            this.cmbBloodGroup.Size = new System.Drawing.Size(100, 26);
            this.cmbBloodGroup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbBloodGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBloodGroup.Items.AddRange(new object[] {
                "A+","A-","B+","B-","AB+","AB-","O+","O-" });

            // Units
            this.lblUnits.Text = "Units";
            this.lblUnits.Location = new System.Drawing.Point(130, 10);
            this.lblUnits.AutoSize = true;
            this.lblUnits.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.txtUnits.Location = new System.Drawing.Point(130, 28);
            this.txtUnits.Size = new System.Drawing.Size(80, 26);
            this.txtUnits.Font = new System.Drawing.Font("Segoe UI", 9F);

            // Remarks
            this.lblRemarks.Text = "Remarks (optional)";
            this.lblRemarks.Location = new System.Drawing.Point(225, 10);
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.txtRemarks.Location = new System.Drawing.Point(225, 28);
            this.txtRemarks.Size = new System.Drawing.Size(280, 26);
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 9F);

            // btnAdd
            this.btnAdd.Text = "+ Add Stock";
            this.btnAdd.Location = new System.Drawing.Point(525, 26);
            this.btnAdd.Size = new System.Drawing.Size(120, 32);
            this.btnAdd.BackColor = System.Drawing.Color.Firebrick;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnDeduct
            this.btnDeduct.Text = "- Deduct Stock";
            this.btnDeduct.Location = new System.Drawing.Point(655, 26);
            this.btnDeduct.Size = new System.Drawing.Size(130, 32);
            this.btnDeduct.BackColor = System.Drawing.Color.Maroon;
            this.btnDeduct.ForeColor = System.Drawing.Color.White;
            this.btnDeduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeduct.FlatAppearance.BorderSize = 0;
            this.btnDeduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeduct.Click += new System.EventHandler(this.btnDeduct_Click);

            // pnlSummary
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.pnlSummary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Size = new System.Drawing.Size(1000, 35);
            this.pnlSummary.Controls.Add(this.lblSummary);

            this.lblSummary.Text = "Current Blood Stock Summary";
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSummary.ForeColor = System.Drawing.Color.Maroon;
            this.lblSummary.Location = new System.Drawing.Point(15, 8);
            this.lblSummary.AutoSize = true;

            // dgvInventory
            this.dgvInventory.Location = new System.Drawing.Point(0, 170);
            this.dgvInventory.Size = new System.Drawing.Size(1000, 440);
            this.dgvInventory.Anchor = System.Windows.Forms.AnchorStyles.Top
                                     | System.Windows.Forms.AnchorStyles.Bottom
                                     | System.Windows.Forms.AnchorStyles.Left
                                     | System.Windows.Forms.AnchorStyles.Right;
            this.dgvInventory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvInventory.RowTemplate.Height = 40;
            this.dgvInventory.ColumnHeadersHeight = 42;

            // Form
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlTop);
            this.Text = "Blood Inventory Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Load += new System.EventHandler(this.FrmBloodInventory_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblBloodGroup;
        private System.Windows.Forms.ComboBox cmbBloodGroup;
        private System.Windows.Forms.Label lblUnits;
        private System.Windows.Forms.TextBox txtUnits;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDeduct;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblSummary;
    }
}