using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.EntityBuilder
{
    /// <summary>
    /// Giao diện định nghĩa các phương thức để xây dựng đối tượng Mail theo mẫu thiết kế Builder
    /// </summary>
    public interface IMailBuilder
    {
        /// <summary>
        /// Thiết lập địa chỉ email người nhận
        /// </summary>
        /// <param name="email">Địa chỉ email người nhận</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        MailBuilder WithEmail(string email);

        /// <summary>
        /// Thiết lập tiêu đề email
        /// </summary>
        /// <param name="title">Tiêu đề email</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        MailBuilder WithTitle(string title);

        /// <summary>
        /// Thiết lập nội dung email
        /// </summary>
        /// <param name="body">Nội dung email</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        MailBuilder WithBody(string body);

        /// <summary>
        /// Tạo và trả về đối tượng Mail với các thuộc tính đã được thiết lập
        /// </summary>
        /// <returns>Đối tượng Mail hoàn chỉnh</returns>
        Mail Build();
    }

    /// <summary>
    /// Lớp triển khai mẫu thiết kế Builder để xây dựng đối tượng Mail theo cách trực quan và linh hoạt
    /// </summary>
    public class MailBuilder : IMailBuilder
    {
        private readonly Mail _mail = new Mail();

        /// <summary>
        /// Thiết lập địa chỉ email người nhận
        /// </summary>
        /// <param name="email">Địa chỉ email người nhận</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        public MailBuilder WithEmail(string email)
        {
            _mail.Email = email;
            return this;
        }

        /// <summary>
        /// Thiết lập tiêu đề email
        /// </summary>
        /// <param name="title">Tiêu đề email</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        public MailBuilder WithTitle(string title)
        {
            _mail.Title = title;
            return this;
        }

        /// <summary>
        /// Thiết lập nội dung email
        /// </summary>
        /// <param name="body">Nội dung email</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        public MailBuilder WithBody(string body)
        {
            _mail.Body = body;
            return this;
        }

        /// <summary>
        /// Tạo và trả về đối tượng Mail với các thuộc tính đã được thiết lập
        /// </summary>
        /// <returns>Đối tượng Mail hoàn chỉnh</returns>
        public Mail Build()
        {
            return _mail;
        }
    }
}
