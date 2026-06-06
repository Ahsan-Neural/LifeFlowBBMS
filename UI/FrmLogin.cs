using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
using LifeFlowBBMS.DAL;

namespace LifeFlowBBMS.UI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        // ─────────────────────────────────────────────────
        //  SECURE HASH (PBKDF2 + Salt)
        // ─────────────────────────────────────────────────
        private string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(salt);

            var pbkdf2 = new Rfc2898DeriveBytes(
                password, salt, 100000, HashAlgorithmName.SHA256);

            byte[] hash = pbkdf2.GetBytes(32);
            byte[] combined = new byte[48];
            Buffer.BlockCopy(salt, 0, combined, 0, 16);
            Buffer.BlockCopy(hash, 0, combined, 16, 32);
            return Convert.ToBase64String(combined);
        }

        // ─────────────────────────────────────────────────
        //  VERIFY HASH
        // ─────────────────────────────────────────────────
        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            try
            {
                byte[] combined = Convert.FromBase64String(storedHash);

                byte[] salt = new byte[16];
                Buffer.BlockCopy(combined, 0, salt, 0, 16);

                var pbkdf2 = new Rfc2898DeriveBytes(
                    enteredPassword, salt, 100000, HashAlgorithmName.SHA256);

                byte[] hash = pbkdf2.GetBytes(32);

                for (int i = 0; i < 32; i++)
                    if (combined[i + 16] != hash[i])
                        return false;

                return true;
            }
            catch (FormatException fex)
            {
                // Log format errors for debugging
                SecurityLogger.LogSecurity("PasswordVerificationError", $"Format error: {fex.Message}");
                System.Diagnostics.Debug.WriteLine($"[SECURITY] Password hash format error: {fex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Log unexpected errors
                SecurityLogger.LogError("FrmLogin.VerifyPassword", $"Unexpected error during password verification", ex);
                System.Diagnostics.Debug.WriteLine($"[SECURITY] Password verification error: {ex.GetType().Name} - {ex.Message}");
                return false;
            }
        }

        // ─────────────────────────────────────────────────
        //  LOGIN
        // ─────────────────────────────────────────────────
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter username.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter password.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                using (SqlConnection con = ConnectionManager.GetConnection())
                {
                    string query = "SELECT FullName, RoleName, PasswordHash FROM Users " +
                                   "WHERE Username=@Username AND IsActive=1";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", username);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        string storedHash = dr["PasswordHash"].ToString();

                        if (VerifyPassword(password, storedHash))
                        {
                            string fullName = dr["FullName"].ToString();
                            string role = dr["RoleName"].ToString();

                            // Log successful login
                            SecurityLogger.LogSuccessfulLogin(username);
                            SecurityLogger.LogAudit(username, "LOGIN_SUCCESS", $"User role: {role}");

                            FrmDashboard dashboard = new FrmDashboard(fullName, role);
                            dashboard.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Log failed authentication attempt
                            SecurityLogger.LogFailedLogin(username, "Invalid password");
                            SecurityLogger.LogAudit(username, "LOGIN_FAILED", "Invalid password");
                            
                            MessageBox.Show("Invalid username or password.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPassword.Clear();
                            txtPassword.Focus();
                        }
                    }
                    else
                    {
                        // Log failed login attempt (user not found)
                        SecurityLogger.LogFailedLogin(username, "User not found");
                        SecurityLogger.LogAudit(username, "LOGIN_FAILED", "User not found or inactive");
                        
                        MessageBox.Show("Invalid username or password.", "Login Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Clear();
                        txtPassword.Focus();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                SecurityLogger.LogError("FrmLogin.btnLogin_Click", "SQL Connection Error", sqlEx);
                System.Diagnostics.Debug.WriteLine($"[ERROR] SQL Connection Error: {sqlEx.Message}");
                MessageBox.Show("Unable to connect to database. Please check your connection settings.",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SecurityLogger.LogError("FrmLogin.btnLogin_Click", "Unexpected error during login", ex);
                System.Diagnostics.Debug.WriteLine($"[ERROR] Unexpected error during login: {ex.GetType().Name} - {ex.Message}");
                MessageBox.Show("An unexpected error occurred. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
