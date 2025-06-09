using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AppIdentityUser : EntityBase
    {
        public string UserName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? Status { get; set; } = UserStatus.WaitingForApproval.ToString();
    }

    public enum UserStatus
    {
        Active,
        Inactive,
        WaitingForApproval,
    }
}
