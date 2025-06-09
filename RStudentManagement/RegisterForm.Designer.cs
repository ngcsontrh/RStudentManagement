namespace RStudentManagement
{
    partial class RegisterForm
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
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            button1 = new Button();
            groupBox2 = new GroupBox();
            textBox2 = new TextBox();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            button2 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MediumSeaGreen;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(442, 560);
            panel1.TabIndex = 0;
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
            panel2.Controls.Add(button1);
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(442, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(504, 560);
            panel2.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.MediumSeaGreen;
            button1.ForeColor = SystemColors.Window;
            button1.Location = new Point(202, 388);
            button1.Name = "button1";
            button1.Size = new Size(127, 38);
            button1.TabIndex = 2;
            button1.Text = "Đăng ký";
            button1.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox2);
            groupBox2.Location = new Point(53, 306);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(426, 63);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Mật khẩu";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 26);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(408, 27);
            textBox2.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(53, 220);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(426, 63);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tên tài khoản";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(408, 27);
            textBox1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(109, 473);
            button2.Name = "button2";
            button2.Size = new Size(216, 38);
            button2.TabIndex = 3;
            button2.Text = "Quay về trang Đăng nhập";
            button2.UseVisualStyleBackColor = true;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 560);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private TextBox textBox1;
        private Button button1;
        private GroupBox groupBox2;
        private TextBox textBox2;
        private Button button2;
    }
}