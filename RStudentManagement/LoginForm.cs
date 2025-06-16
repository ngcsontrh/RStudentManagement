using RStudentManagement.Core;
using RStudentManagement.Core.Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace RStudentManagement
{
    public partial class LoginForm : Form
    {
        private readonly ILogger _logger;
        private readonly DatabaseManager _databaseManager;

        public LoginForm()
        {
            InitializeComponent();
            _logger = LoggerFactory.Instance.GetLogger(AppConfig.LoggerType);
            _databaseManager = new DatabaseManager(AppConfig.DbConnectionString);
        }

        private void register_button_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            this.Close();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            try
            {
                string username = username_textBox.Text;
                string password = password_textBox.Text;
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string query = "SELECT * FROM Accounts WHERE UserName = @UserName AND PasswordHash = @PasswordHash";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@UserName", username),
                        new SqlParameter("@PasswordHash", password)
                    };

                    DataTable result = _databaseManager.ExecuteQuery(query, parameters);
                    if (result.Rows.Count > 0)
                    {
                        _logger.LogInfo($"User {username} logged in successfully.");
                        AccountForm accountForm = new AccountForm();
                        accountForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Login failed", ex);
                MessageBox.Show("An error occurred while trying to log in. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
