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
            panel1.Name = "panel1";
            panel1.Size = new Size(442, 560);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Controls.Add(register_button);
            panel3.Location = new Point(0, 441);
            panel3.Name = "panel3";
            panel3.Size = new Size(442, 67);
            panel3.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Window;
            label3.Location = new Point(12, 13);
            label3.Name = "label3";
            label3.Size = new Size(259, 38);
            label3.TabIndex = 3;
            label3.Text = "Chưa có tài khoản?";
            // 
            // register_button
            // 
            register_button.Location = new Point(277, 18);
            register_button.Name = "register_button";
            register_button.Size = new Size(143, 38);
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
            label2.Location = new Point(21, 195);
            label2.Name = "label2";
            label2.Size = new Size(395, 38);
            label2.TabIndex = 1;
            label2.Text = "Hệ Thống Quản Lý Sinh Viên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(43, 117);
            label1.Name = "label1";
            label1.Size = new Size(352, 41);
            label1.TabIndex = 0;
            label1.Text = "R Student Management";
            // 
            // panel2
            // 
            panel2.Controls.Add(login_button);
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(442, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(504, 560);
            panel2.TabIndex = 1;
            // 
            // login_button
            // 
            login_button.BackColor = Color.MediumSeaGreen;
            login_button.ForeColor = SystemColors.Window;
            login_button.Location = new Point(202, 388);
            login_button.Name = "login_button";
            login_button.Size = new Size(127, 38);
            login_button.TabIndex = 2;
            login_button.Text = "Đăng nhập";
            login_button.UseVisualStyleBackColor = false;
            login_button.Click += this.login_button_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(password_textBox);
            groupBox2.Location = new Point(53, 306);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(426, 63);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Mật khẩu";
            // 
            // password_textBox
            // 
            password_textBox.Location = new Point(12, 26);
            password_textBox.Name = "password_textBox";
            password_textBox.Size = new Size(408, 27);
            password_textBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(username_textBox);
            groupBox1.Location = new Point(53, 220);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(426, 63);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tên tài khoản";
            // 
            // username_textBox
            // 
            username_textBox.Location = new Point(12, 26);
            username_textBox.Name = "username_textBox";
            username_textBox.Size = new Size(408, 27);
            username_textBox.TabIndex = 0;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 560);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
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