using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.UIProvider
{
    public class FontFlyweight
    {
        private readonly Font _font;

        public FontFlyweight(string fontFamily, float fontSize, FontStyle fontStyle)
        {
            _font = new Font(fontFamily, fontSize, fontStyle);
        }

        public Font GetFont()
        {
            return _font;
        }
    }

    public class FontFlyweightFactory
    {
        private readonly Dictionary<string, FontFlyweight> _fonts = new();

        private FontFlyweightFactory() { }

        public static FontFlyweightFactory Instance { get; } = new FontFlyweightFactory();

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
