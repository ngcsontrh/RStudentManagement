using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.UIProvider
{
    public interface IThemeFactory
    {
        IButton CreateButton();
        ITextBox CreateTextBox();
        ILabel CreateLabel();
    }

    public interface IButton
    {
        Control GetControl();
    }

    public interface ITextBox
    {
        Control GetControl();
    }
    public interface ILabel
    {
        Control GetControl();
    }
}