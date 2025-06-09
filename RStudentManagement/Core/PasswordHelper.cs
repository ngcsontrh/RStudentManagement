using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Core
{
    internal class PasswordHelper
    {
        private PasswordHelper() { }

        public static PasswordHelper Instance { get; } = new PasswordHelper();

        public string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be null or empty.", nameof(password));
            }
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be null or empty.", nameof(password));
            }
            if (string.IsNullOrEmpty(hashedPassword))
            {
                throw new ArgumentException("Hashed password cannot be null or empty.", nameof(hashedPassword));
            }
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
