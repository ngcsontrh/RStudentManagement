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
        public LoginForm()
        {
            InitializeComponent();
        }

        private void register_button_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            this.Close();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            // Here you would typically validate the username and password
            // For now, we will just show a message box
            string username = username_textBox.Text;
            string password = password_textBox.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Welcome {username}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StudentForm studentForm = new StudentForm();
                studentForm.ShowDialog();                
                this.Close();
            }
        }
    }
}
