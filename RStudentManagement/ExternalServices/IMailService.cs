using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.ExternalServices
{
    internal interface IMailService
    {
        Task<bool> SendAsync(Mail mail);
    }
}
