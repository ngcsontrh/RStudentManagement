using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Strategies
{
    public interface IExportStrategy
    {
        void Export(IEnumerable<Student> students, string filePath);
    }
}
