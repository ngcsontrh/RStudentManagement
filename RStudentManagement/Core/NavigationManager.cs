using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Core
{
    public enum SidebarItem
    {
        Personal,
        Account,
        Student,
        Email
    }

    internal class NavigationManager
    {
        private NavigationManager() { }

        public static NavigationManager Instance { get; } = new NavigationManager();

        public void NavigateTo(SidebarItem item, Form currentForm)
        {
            Form? newForm = item switch
            {
                SidebarItem.Personal => new AccountForm(),
                SidebarItem.Account => new AccountForm(),
                SidebarItem.Student => new StudentForm(),
                _ => null
            };
            if (newForm != null)
            {
                currentForm.Hide();
                newForm.ShowDialog();
                currentForm.Close();
            }
        }
    }
}
