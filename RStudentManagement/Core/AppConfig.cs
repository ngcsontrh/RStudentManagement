using Core.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Core
{
    internal static class AppConfig
    {
        public static LoggerType LoggerType { get; set; } = LoggerType.Console;
        public static string DbConnectionString { get; set; } = "Server=localhost;Database=RStudentManagement;User Id=sa;Password=your_password;TrustServerCertificate=True;";
    }
}
