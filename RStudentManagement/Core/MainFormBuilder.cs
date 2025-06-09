using System;
using System.Windows.Forms;

namespace RStudentManagement.Core
{
    internal interface IMainFormBuilder
    {
        IMainFormBuilder WithMainForm(Func<Form> mainFormFactory);
        IMainFormBuilder OnStart(Action onStart);
        IMainFormBuilder OnLoad(Action onLoad);
        IMainFormBuilder OnExit(Action onExit);
        Form Build();
    }

    internal class MainFormBuilder : IMainFormBuilder
    {
        private Form? _form;

        private Action? _onStart;
        private Action? _onLoad;
        private Action? _onExit;

        public IMainFormBuilder WithMainForm(Func<Form> mainFormFactory)
        {
            if (mainFormFactory == null)
                throw new ArgumentNullException(nameof(mainFormFactory));

            _form = mainFormFactory();

            return this;
        }

        public IMainFormBuilder OnStart(Action onStart)
        {
            _onStart = onStart ?? throw new ArgumentNullException(nameof(onStart));
            return this;
        }

        public IMainFormBuilder OnLoad(Action onLoad)
        {
            _onLoad = onLoad ?? throw new ArgumentNullException(nameof(onLoad));
            return this;
        }

        public IMainFormBuilder OnExit(Action onExit)
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

            if (_onLoad != null)
                _form.Shown += (s, e) => _onLoad();

            if (_onExit != null)
                _form.FormClosed += (s, e) => _onExit();

            return _form;
        }        
    }
}
