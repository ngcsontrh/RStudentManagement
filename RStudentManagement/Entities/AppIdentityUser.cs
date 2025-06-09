using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Entities
{
    public class AppIdentityUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? Status { get; set; } = UserStatus.WaitingForApproval.ToString();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum UserStatus
    {
        Active,
        Inactive,
        WaitingForApproval,
    }
}
