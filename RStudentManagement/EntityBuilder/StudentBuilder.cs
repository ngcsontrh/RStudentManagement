using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.EntityBuilder
{
    public interface IStudentBuilder
    {
        StudentBuilder WithCode(string code);
        StudentBuilder WithFullName(string fullName);
        StudentBuilder WithDateOfBirth(DateTime dateOfBirth);
        StudentBuilder WithAddress(string address);
        StudentBuilder WithEmail(string email);
        StudentBuilder WithClass(string clazz);
        Student Build();
    }

    public class StudentBuilder : IStudentBuilder
    {
        private readonly Student _student = new Student();

        public StudentBuilder WithCode(string code)
        {
            _student.Code = code;
            return this;
        }
        public StudentBuilder WithFullName(string fullName)
        {
            _student.FullName = fullName;
            return this;
        }
        public StudentBuilder WithDateOfBirth(DateTime dateOfBirth)
        {
            _student.DateOfBirth = dateOfBirth;
            return this;
        }
        public StudentBuilder WithAddress(string address)
        {
            _student.Address = address;
            return this;
        }
        public StudentBuilder WithEmail(string email)
        {
            _student.Email = email;
            return this;
        }
        public StudentBuilder WithClass(string clazz)
        {
            _student.Class = clazz;
            return this;
        }
        public Student Build()
        {
            return _student;
        }        
    }
}
