using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Adapters
{
    public class StudentClassAdapter : IStudentClassAdapter
    {
        private readonly StudentClassesAdaptee _studentClassesAdaptee;

        public StudentClassAdapter(StudentClassesAdaptee studentClassesAdaptee)
        {
            _studentClassesAdaptee = studentClassesAdaptee;
        }

        public List<StudentClass> GetStudentClasses()
        {
            var studentClasses = _studentClassesAdaptee.GetAvailableClasses();
            var adaptedClasses = new List<StudentClass>();
            foreach (var studentClass in studentClasses)
            {
                var classParts = studentClass.Split(" - ");
                if (classParts.Length == 2)
                {
                    adaptedClasses.Add(new StudentClass
                    {
                        Code = classParts[0],
                        Name = classParts[1]
                    });
                }
            }
            return adaptedClasses;
        }
    }
}
