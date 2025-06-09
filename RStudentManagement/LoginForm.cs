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

namespace RStudentManagement
{
    public partial class LoginForm : Form
    {
        private readonly ILogger _logger;
        public LoginForm()
        {
            InitializeComponent();
            _logger = LoggerFactory.Instance.GetLogger(AppConfig.LoggerType);
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
                    _logger.LogInfo($"User {username} logged in successfully.");
                    AccountForm accountForm = new AccountForm();
                    accountForm.ShowDialog();
                    this.Close();
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
