using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Strategies
{
    /// <summary>
    /// Interface đại diện cho mẫu thiết kế Strategy cho việc xuất dữ liệu sinh viên
    /// Interface này định nghĩa một phương thức Export chung cho tất cả các chiến lược xuất khác nhau
    /// </summary>
    public interface IExportStrategy
    {
        /// <summary>
        /// Xuất danh sách sinh viên ra file với định dạng tùy theo chiến lược cụ thể
        /// </summary>
        /// <param name="students">Danh sách sinh viên cần xuất</param>
        /// <param name="filePath">Đường dẫn đến file xuất</param>
        void Export(IEnumerable<Student> students, string filePath);
    }
}
