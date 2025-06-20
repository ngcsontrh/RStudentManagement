using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Strategies
{
    public class CsvExportStrategy : IExportStrategy
    {
        public void Export(IEnumerable<Student> students, string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Code,FullName,DateOfBirth,Email,Address,Class");

            foreach (var s in students)
            {
                sb.AppendLine($"{s.Code},{s.FullName},{s.DateOfBirth:yyyy-MM-dd},{s.Email},{s.Address},{s.Class}");
            }

            File.WriteAllText(filePath, sb.ToString(), new UTF8Encoding(true));
        }
    }
}
