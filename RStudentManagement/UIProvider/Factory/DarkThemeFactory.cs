using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.UIProvider.Factory
{
    public class DarkThemeFactory : IThemeFactory
    {
        public IButton CreateButton()
        {
            return new DarkThemeButton();
        }
        public ITextBox CreateTextBox()
        {
            return new DarkThemeTextBox();
        }
        public ILabel CreateLabel()
        {
            return new DarkThemeLabel();
        }
    }

    public class DarkThemeButton : IButton
    {
        public Control GetControl()
        {
            var font = FontFlyweightFactory.Instance.GetFont("Segoe UI", 10, FontStyle.Regular).GetFont();
            return new Button { BackColor = Color.DarkGray, ForeColor = Color.White, Font = font };
        }
    }

    public class DarkThemeTextBox : ITextBox
    {
        public Control GetControl()
        {
            var font = FontFlyweightFactory.Instance.GetFont("Segoe UI", 10, FontStyle.Regular).GetFont();
            return new TextBox { BackColor = Color.Black, ForeColor = Color.White, Font = font };
        }
    }

    public class DarkThemeLabel : ILabel
    {
        public Control GetControl()
        {
            var font = FontFlyweightFactory.Instance.GetFont("Segoe UI", 10, FontStyle.Regular).GetFont();
            return new Label { BackColor = Color.Transparent, ForeColor = Color.White, Font = font };
        }
    }
}
