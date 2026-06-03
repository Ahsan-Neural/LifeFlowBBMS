using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using LifeFlowBBMS.DAL;

namespace LifeFlowBBMS.UI
{
    public class FrmAddEditRequest : Form
    {
        private int _requestId = -1;

        private Panel pnlTop;
        private Label lblTitle;
        private Label lblPatient, lblBloodGroup, lblUnits,
                        lblHospital, lblContact, lblNotes, lblStatus;
        private TextBox txtPatient, txtUnits, txtHospital, txtContact, txtNotes;
        private ComboBox cmbBloodGroup, cmbStatus;
        private Button btnSave, btnCancel;

        public FrmAddEditRequest(int requestId = -1)
        {
            _requestId = requestId;
            BuildForm();
            if (_requestId != -1)
                LoadRequestData();
        }

        private void BuildForm()
        {
            this.Text = _requestId == -1 ? "Add Request" : "Edit Request";
            this.ClientSize = new Size(480, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Font = new Font("Segoe UI", 10F);

            pnlTop = new Panel
            {
                BackColor = Color.Firebrick,
                Dock = DockStyle.Top,
                Height = 55
            };
            lblTitle = new Label
            {
                Text = _requestId == -1 ? "New Blood Request" : "Edit Request",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 12),
                AutoSize = true
            };
            pnlTop.Controls.Add(lblTitle);

            int left = 25, ctrlX = 160, ctrlW = 280, gap = 48, top = 70;

            lblPatient = MakeLabel("Patient Name *", left, top);
            txtPatient = new TextBox { Location = new Point(ctrlX, top - 3), Size = new Size(ctrlW, 26) };

            lblBloodGroup = MakeLabel("Blood Group *", left, top + gap);
            cmbBloodGroup = new ComboBox
            {
                Location = new Point(ctrlX, top + gap - 3),
                Size = new Size(120, 26),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbBloodGroup.Items.AddRange(new object[] {
                "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" });
            cmbBloodGroup.SelectedIndex = 0;

            lblUnits = MakeLabel("Units *", left, top + gap * 2);
            txtUnits = new TextBox { Location = new Point(ctrlX, top + gap * 2 - 3), Size = new Size(100, 26) };

            lblHospital = MakeLabel("Hospital *", left, top + gap * 3);
            txtHospital = new TextBox { Location = new Point(ctrlX, top + gap * 3 - 3), Size = new Size(ctrlW, 26) };

            lblContact = MakeLabel("Contact No", left, top + gap * 4);
            txtContact = new TextBox { Location = new Point(ctrlX, top + gap * 4 - 3), Size = new Size(160, 26) };

            lblStatus = MakeLabel("Status", left, top + gap * 5);
            cmbStatus = new ComboBox
            {
                Location = new Point(ctrlX, top + gap * 5 - 3),
                Size = new Size(130, 26),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbStatus.Items.AddRange(new object[] { "Pending", "Approved", "Rejected" });
            cmbStatus.SelectedIndex = 0;

            lblNotes = MakeLabel("Notes", left, top + gap * 6);
            txtNotes = new TextBox
            {
                Location = new Point(ctrlX, top + gap * 6 - 3),
                Size = new Size(ctrlW, 55),
                Multiline = true
            };

            btnSave = new Button
            {
                Text = "Save",
                Location = new Point(160, top + gap * 7 + 10),
                Size = new Size(120, 36),
                BackColor = Color.Firebrick,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(295, top + gap * 7 + 10),
                Size = new Size(100, 36),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F)
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            this.Controls.AddRange(new Control[] {
                pnlTop,
                lblPatient,    txtPatient,
                lblBloodGroup, cmbBloodGroup,
                lblUnits,      txtUnits,
                lblHospital,   txtHospital,
                lblContact,    txtContact,
                lblStatus,     cmbStatus,
                lblNotes,      txtNotes,
                btnSave,       btnCancel
            });
        }

        private Label MakeLabel(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                ForeColor = Color.FromArgb(60, 60, 60),
                Font = new Font("Segoe UI", 10F)
            };
        }

        private void LoadRequestData()
        {
            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT * FROM BloodRequests WHERE RequestID=@id", con);
                    cmd.Parameters.AddWithValue("@id", _requestId);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtPatient.Text = dr["PatientName"].ToString();
                        cmbBloodGroup.SelectedItem = dr["BloodGroup"].ToString();
                        txtUnits.Text = dr["Units"].ToString();
                        txtHospital.Text = dr["Hospital"].ToString();
                        txtContact.Text = dr["ContactNo"].ToString();
                        cmbStatus.SelectedItem = dr["Status"].ToString();
                        txtNotes.Text = dr["Notes"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPatient.Text) ||
                string.IsNullOrWhiteSpace(txtUnits.Text) ||
                string.IsNullOrWhiteSpace(txtHospital.Text))
            {
                MessageBox.Show("Patient Name, Units and Hospital are required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtUnits.Text, out int units) || units <= 0)
            {
                MessageBox.Show("Please enter a valid number of units.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    con.Open();
                    SqlCommand cmd;

                    if (_requestId == -1)
                    {
                        cmd = new SqlCommand(@"INSERT INTO BloodRequests
                            (PatientName, BloodGroup, Units, Hospital,
                             ContactNo, Status, RequestDate, Notes)
                            VALUES (@patient, @bg, @units, @hospital,
                                    @contact, @status, GETDATE(), @notes)", con);
                    }
                    else
                    {
                        cmd = new SqlCommand(@"UPDATE BloodRequests SET
                            PatientName=@patient, BloodGroup=@bg,
                            Units=@units, Hospital=@hospital,
                            ContactNo=@contact, Status=@status,
                            Notes=@notes
                            WHERE RequestID=@id", con);
                        cmd.Parameters.AddWithValue("@id", _requestId);
                    }

                    cmd.Parameters.AddWithValue("@patient", txtPatient.Text.Trim());
                    cmd.Parameters.AddWithValue("@bg", cmbBloodGroup.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@units", units);
                    cmd.Parameters.AddWithValue("@hospital", txtHospital.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact", txtContact.Text.Trim());
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@notes", txtNotes.Text.Trim());

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    _requestId == -1 ? "Request added!" : "Request updated!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}