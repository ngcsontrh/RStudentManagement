using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Strategies
{
    /// <summary>
    /// Chiến lược xuất dữ liệu sinh viên sang file CSV
    /// Triển khai giao diện IExportStrategy để xuất dữ liệu dưới định dạng Comma-Separated Values
    /// </summary>
    public class CsvExportStrategy : IExportStrategy
    {
        /// <summary>
        /// Xuất danh sách sinh viên ra file CSV
        /// </summary>
        /// <param name="students">Danh sách sinh viên cần xuất</param>
        /// <param name="filePath">Đường dẫn đến file CSV xuất</param>
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
