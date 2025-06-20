using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Adapters
{
    /// <summary>
    /// Interface Target trong mẫu thiết kế Adapter, định nghĩa giao diện mà client sẽ sử dụng
    /// Interface này đóng vai trò là mục tiêu cần được thích ứng phù hợp với nhu cầu của client
    /// </summary>
    public interface IStudentClassAdapter
    {
        /// <summary>
        /// Lấy danh sách các lớp học đã được chuyển đổi thành đối tượng StudentClass
        /// </summary>
        /// <returns>Danh sách các đối tượng StudentClass với thông tin Code và Name đã được trích xuất</returns>
        List<StudentClass> GetStudentClasses();
    }
}
