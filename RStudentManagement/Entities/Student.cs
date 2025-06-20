using RStudentManagement.Prototype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Entities
{
    public class Student : ICloneable<Student>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Code { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Class { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Student Clone()
        {
            return (Student)this.MemberwiseClone();
        }
    }    
}
