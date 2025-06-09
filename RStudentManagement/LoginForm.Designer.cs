namespace RStudentManagement
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel3 = new Panel();
            label3 = new Label();
            register_button = new Button();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            login_button = new Button();
            groupBox2 = new GroupBox();
            password_textBox = new TextBox();
            groupBox1 = new GroupBox();
            username_textBox = new TextBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MediumSeaGreen;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(387, 420);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Controls.Add(register_button);
            panel3.Location = new Point(0, 331);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(387, 50);
            panel3.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Window;
            label3.Location = new Point(10, 10);
            label3.Name = "label3";
            label3.Size = new Size(203, 30);
            label3.TabIndex = 3;
            label3.Text = "Chưa có tài khoản?";
            // 
            // register_button
            // 
            register_button.Location = new Point(242, 14);
            register_button.Margin = new Padding(3, 2, 3, 2);
            register_button.Name = "register_button";
            register_button.Size = new Size(125, 28);
            register_button.TabIndex = 2;
            register_button.Text = "Tạo tài khoản";
            register_button.UseVisualStyleBackColor = true;
            register_button.Click += register_button_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Window;
            label2.Location = new Point(18, 146);
            label2.Name = "label2";
            label2.Size = new Size(306, 30);
            label2.TabIndex = 1;
            label2.Text = "Hệ Thống Quản Lý Sinh Viên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(38, 88);
            label1.Name = "label1";
            label1.Size = new Size(283, 32);
            label1.TabIndex = 0;
            label1.Text = "R Student Management";
            // 
            // panel2
            // 
            panel2.Controls.Add(login_button);
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(387, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(441, 420);
            panel2.TabIndex = 1;
            // 
            // login_button
            // 
            login_button.BackColor = Color.MediumSeaGreen;
            login_button.ForeColor = SystemColors.Window;
            login_button.Location = new Point(177, 291);
            login_button.Margin = new Padding(3, 2, 3, 2);
            login_button.Name = "login_button";
            login_button.Size = new Size(111, 28);
            login_button.TabIndex = 2;
            login_button.Text = "Đăng nhập";
            login_button.UseVisualStyleBackColor = false;
            login_button.Click += login_button_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(password_textBox);
            groupBox2.Location = new Point(46, 230);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(373, 47);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Mật khẩu";
            // 
            // password_textBox
            // 
            password_textBox.Location = new Point(10, 20);
            password_textBox.Margin = new Padding(3, 2, 3, 2);
            password_textBox.Name = "password_textBox";
            password_textBox.Size = new Size(358, 23);
            password_textBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(username_textBox);
            groupBox1.Location = new Point(46, 165);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(373, 47);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tên tài khoản";
            // 
            // username_textBox
            // 
            username_textBox.Location = new Point(10, 20);
            username_textBox.Margin = new Padding(3, 2, 3, 2);
            username_textBox.Name = "username_textBox";
            username_textBox.Size = new Size(358, 23);
            username_textBox.TabIndex = 0;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 420);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private GroupBox groupBox1;
        private TextBox username_textBox;
        private Button login_button;
        private GroupBox groupBox2;
        private TextBox password_textBox;
        private Button register_button;
        private Panel panel3;
        private Label label3;
    }
}