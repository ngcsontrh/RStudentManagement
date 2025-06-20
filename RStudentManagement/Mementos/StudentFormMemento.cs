using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Mementos
{
    public class StudentFormMemento
    {
        public string Code { get; }
        public string FullName { get; }
        public DateTime DateOfBirth { get; }
        public string Email { get; }
        public string Address { get; }
        public string ClassCode { get; }

        public StudentFormMemento(string code, string fullName, DateTime dob, string email, string address, string classCode)
        {
            Code = code;
            FullName = fullName;
            DateOfBirth = dob;
            Email = email;
            Address = address;
            ClassCode = classCode;
        }
    }

}
