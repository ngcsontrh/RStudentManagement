using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Adapters
{
    public class StudentClassesAdaptee
    {
        public List<string> GetAvailableClasses()
        {
            return new List<string>
            {
                "M101 - Mathematics 101",
                "CS102 - Computer Science 102",
                "M103 - Mathematics 103",
                "CS104 - Computer Science 104",
                "PHY105 - Physics 105"
            };
        }
    }
}
