using RStudentManagement.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RStudentManagement.Components
{
    public partial class SidebarControl : UserControl
    {
        public event EventHandler<SidebarItem>? SidebarItemClicked;

        public SidebarControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidebarItemClicked?.Invoke(this, SidebarItem.Personal);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidebarItemClicked?.Invoke(this, SidebarItem.Student);
        }
    }
}
