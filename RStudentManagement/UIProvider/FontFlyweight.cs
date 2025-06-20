using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.UIProvider
{
    /// <summary>
    /// Thực hiện mẫu thiết kế Flyweight cho các đối tượng font để giảm thiểu việc sử dụng bộ nhớ.
    /// Mỗi font duy nhất chỉ được khởi tạo một lần và được chia sẻ trong toàn bộ ứng dụng.
    /// </summary>
    public class FontFlyweight
    {
        private readonly Font _font;

        /// <summary>
        /// Khởi tạo một thể hiện mới của lớp <see cref="FontFlyweight"/>.
        /// </summary>
        /// <param name="fontFamily">Tên của họ font.</param>
        /// <param name="fontSize">Kích thước em của font tính bằng điểm.</param>
        /// <param name="fontStyle">Kiểu <see cref="FontStyle"/> của font.</param>
        public FontFlyweight(string fontFamily, float fontSize, FontStyle fontStyle)
        {
            _font = new Font(fontFamily, fontSize, fontStyle);
        }

        /// <summary>
        /// Lấy đối tượng Font được đóng gói bởi flyweight này.
        /// </summary>
        /// <returns>Một đối tượng <see cref="Font"/>.</returns>
        public Font GetFont()
        {
            return _font;
        }
    }

    /// <summary>
    /// Lớp Factory để tạo và quản lý các thể hiện <see cref="FontFlyweight"/>.
    /// Đảm bảo rằng chỉ có một thể hiện duy nhất cho mỗi cấu hình font tồn tại.
    /// Thực hiện mẫu thiết kế Singleton để cung cấp một điểm truy cập duy nhất.
    /// </summary>
    public class FontFlyweightFactory
    {
        private readonly Dictionary<string, FontFlyweight> _fonts = new();

        /// <summary>
        /// Constructor riêng tư để ngăn chặn việc khởi tạo từ bên ngoài.
        /// </summary>
        private FontFlyweightFactory() { }

        /// <summary>
        /// Lấy thể hiện singleton của lớp <see cref="FontFlyweightFactory"/>.
        /// </summary>
        public static FontFlyweightFactory Instance { get; } = new FontFlyweightFactory();

        /// <summary>
        /// Lấy một <see cref="FontFlyweight"/> với các tham số đã chỉ định.
        /// Nếu một font tương ứng đã tồn tại, trả về thể hiện đã có; nếu không, tạo một thể hiện mới.
        /// </summary>
        /// <param name="fontFamily">Tên của họ font.</param>
        /// <param name="fontSize">Kích thước em của font tính bằng điểm.</param>
        /// <param name="fontStyle">Kiểu <see cref="FontStyle"/> của font.</param>
        /// <returns>Một đối tượng <see cref="FontFlyweight"/> với các tham số đã chỉ định.</returns>
        public FontFlyweight GetFont(string fontFamily, float fontSize, FontStyle fontStyle)
        {
            string key = $"{fontFamily}_{fontSize}_{fontStyle.ToString()}";
            if (!_fonts.TryGetValue(key, out var fontFlyweight))
            {
                fontFlyweight = new FontFlyweight(fontFamily, fontSize, fontStyle);
                _fonts[key] = fontFlyweight;
            }
            return fontFlyweight;
        }
    }
}
