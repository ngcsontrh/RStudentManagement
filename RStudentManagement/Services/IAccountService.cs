using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Services
{
    internal interface IAccountService
    {
        Task<bool> LoginAsync(string username, string password);
        Task<bool> RegisterAsync(string username, string password, string email);
        Task<bool> ChangePasswordAsync(string username, string oldPassword, string newPassword);
        Task<Account> GetInfoAsync(string username);
    }
}
