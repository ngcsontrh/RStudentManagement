using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Prototype
{
    /// <summary>
    /// Interface đại diện cho mẫu thiết kế Prototype cho phép tạo bản sao của đối tượng
    /// Interface này định nghĩa một phương thức Clone cho việc sao chép đối tượng mà không cần biết cụ thể về lớp của chúng
    /// </summary>
    /// <typeparam name="T">Kiểu của đối tượng cần sao chép, phải là một kiểu tham chiếu (reference type)</typeparam>
    public interface ICloneable<T> where T : class
    {
        /// <summary>
        /// Tạo một bản sao của đối tượng hiện tại
        /// </summary>
        /// <returns>Một bản sao của đối tượng hiện tại</returns>
        T Clone();
    }
}
