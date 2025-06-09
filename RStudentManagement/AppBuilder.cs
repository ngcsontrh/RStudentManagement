using System;
using System.Windows.Forms;

namespace RStudentManagement
{
    internal class AppBuilder
    {
        private Form? _form;

        private Action? _onStart;
        private Action? _onExit;

        public AppBuilder WithMainForm(Func<Form> mainFormFactory)
        {
            if (mainFormFactory == null)
                throw new ArgumentNullException(nameof(mainFormFactory));

            _form = mainFormFactory();

            return this;
        }

        public AppBuilder OnStart(Action onStart)
        {
            _onStart = onStart ?? throw new ArgumentNullException(nameof(onStart));
            return this;
        }

        public AppBuilder OnExit(Action onExit)
        {
            _onExit = onExit ?? throw new ArgumentNullException(nameof(onExit));
            return this;
        }

        public Form Build()
        {
            if (_form == null)
                throw new InvalidOperationException("Main form must be set before building.");

            if (_onStart != null)
                _form.Load += (s, e) => _onStart();

            if (_onExit != null)
                _form.FormClosed += (s, e) => _onExit();

            return _form;
        }
    }
}
