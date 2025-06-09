using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Services
{
    internal interface IAuditLogService
    {
        Task LogAuditAsync(AuditLog log);
    }
}
