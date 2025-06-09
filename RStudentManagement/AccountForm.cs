using RStudentManagement.Core;
using RStudentManagement.Entities;
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
    public partial class AccountForm : Form
    {
        private List<Account> appIdentityUsers = new List<Account>();

        public AccountForm()
        {
            InitializeComponent();
            sidebarControl1.SidebarItemClicked += SidebarControl1_SidebarItemClicked;
        }

        private void SidebarControl1_SidebarItemClicked(object? sender, SidebarItem e)
        {
            NavigationManager.Instance.NavigateTo(e, this);
        }
    }
}
