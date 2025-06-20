using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Strategies
{
    /// <summary>
    /// Lớp ngữ cảnh sử dụng trong mẫu thiết kế Strategy để quản lý các chiến lược xuất dữ liệu
    /// Cho phép thay đổi chiến lược xuất tại thời điểm chạy
    /// </summary>
    public class ExportContext
    {
        private IExportStrategy _strategy;

        /// <summary>
        /// Khởi tạo ngữ cảnh xuất với một chiến lược cụ thể
        /// </summary>
        /// <param name="strategy">Chiến lược xuất dữ liệu cần sử dụng</param>
        public ExportContext(IExportStrategy strategy)
        {
            _strategy = strategy;
        }

        /// <summary>
        /// Thay đổi chiến lược xuất dữ liệu tại thời điểm chạy
        /// </summary>
        /// <param name="strategy">Chiến lược xuất dữ liệu mới cần sử dụng</param>
        public void SetStrategy(IExportStrategy strategy)
        {
            _strategy = strategy;
        }

        /// <summary>
        /// Xuất dữ liệu sử dụng chiến lược hiện tại
        /// </summary>
        /// <param name="students">Danh sách sinh viên cần xuất</param>
        /// <param name="filePath">Đường dẫn đến file xuất</param>
        public void Export(IEnumerable<Student> students, string filePath)
        {
            _strategy.Export(students, filePath);
        }
    }

}
