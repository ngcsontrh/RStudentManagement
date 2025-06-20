using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.UIProvider.Factory
{
    public class LightThemeFactory : IThemeFactory
    {
        public IButton CreateButton()
        {
            return new LightThemeButton();
        }
        public ITextBox CreateTextBox()
        {
            return new LightThemeTextBox();
        }
        public ILabel CreateLabel()
        {
            return new LightThemeLabel();
        }
    }

    public class LightThemeButton : IButton
    {
        public Control GetControl()
        {
            var font = FontFlyweightFactory.Instance.GetFont("Arial", 10, FontStyle.Regular).GetFont();
            return new Button { BackColor = Color.LightGray, ForeColor = Color.Black, Font = font };
        }
    }

    public class LightThemeTextBox : ITextBox
    {
        public Control GetControl()
        {
            var font = FontFlyweightFactory.Instance.GetFont("Arial", 10, FontStyle.Regular).GetFont();
            return new TextBox { BackColor = Color.White, ForeColor = Color.Black, Font = font };
        }
    }

    public class LightThemeLabel : ILabel
    {
        public Control GetControl()
        {
            var font = FontFlyweightFactory.Instance.GetFont("Arial", 10, FontStyle.Regular).GetFont();
            return new Label { BackColor = Color.Transparent, ForeColor = Color.Black, Font = font };
        }
    }
}
