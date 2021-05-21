using Design.StudyApp.ActiveViewManager;
using Prism.Mvvm;
using System;
using System.Reactive.Disposables;
using System.Reactive.Subjects;

namespace StudyApp.DockingContent.Base.ViewModels
{
    public class ContentBaseViewModel : BindableBase, IActiveView, IDisposable
    {
        protected CompositeDisposable Disposables { get; } = new CompositeDisposable();

        protected IActiveViewManager ActiveViewManager { get; }

        public ICommand Copy { get; }

        public ICommand Paste { get; }

        public ContentBaseViewModel(IActiveViewManager activeViewManager)
        {
            ActiveViewManager = activeViewManager;

            Copy = new Command(CopyFunction, true);
            Paste = new Command(PasteFunction, true);
        }

        public void Activate()
        {
            ActiveViewManager.Activate(this);
        }

        protected virtual void CopyFunction()
        {
        }

        protected virtual void PasteFunction()
        {
        }

        public void Dispose()
        {
            Disposables.Dispose();
        }
    }

    internal class Command : ICommand
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        private readonly Action _action;
        private readonly Subject<bool> _isEnabled = new Subject<bool>();

        public ISubject<bool> IsEnabled { get { return _isEnabled; } }

        public Command(Action action, bool isEnalbed)
        {
            _disposables.Add(_isEnabled);
            _isEnabled.OnNext(isEnalbed);
            _action = action;
        }

        public void Execute()
        {
            _action();
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
