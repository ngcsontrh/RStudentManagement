namespace RStudentManagement.Components
{
    partial class SidebarControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(22, 86);
            label1.Name = "label1";
            label1.Size = new Size(183, 21);
            label1.TabIndex = 2;
            label1.Text = "R Student Management";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(9, 143);
            button1.Name = "button1";
            button1.Size = new Size(208, 38);
            button1.TabIndex = 4;
            button1.Text = "Cá nhân";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(9, 204);
            button2.Name = "button2";
            button2.Size = new Size(208, 38);
            button2.TabIndex = 6;
            button2.Text = "Quản lý sinh viên";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // SidebarControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSeaGreen;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "SidebarControl";
            Size = new Size(225, 551);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button button1;
        private Button button2;
    }
}
