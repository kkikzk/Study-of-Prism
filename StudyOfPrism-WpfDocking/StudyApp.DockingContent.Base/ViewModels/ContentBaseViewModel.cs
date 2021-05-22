using Design.StudyApp;
using Design.StudyApp.ActiveViewManager;
using Prism.Mvvm;
using System;
using System.Reactive.Disposables;
using System.Reactive.Subjects;

namespace StudyApp.DockingContent.Base.ViewModels
{
    public class ContentBaseViewModel : BindableBase, IActiveView, IDisposable
    {
        protected class Command : ICommand, IDisposable
        {
            internal class ObservableWithValue<T> : IObservableWithValue<T>, IDisposable
            {
                private readonly CompositeDisposable _disposables = new CompositeDisposable();

                public IObservable<T> Observable { get; }

                public T Value { private set; get; }

                internal ObservableWithValue(IObservable<T> observable, T value)
                {
                    Observable = observable;
                    Value = value;

                    _disposables.Add(Observable.Subscribe(_ =>
                    {
                        Value = _;
                    }));
                }

                public void Dispose()
                {
                    _disposables.Dispose();
                }
            }

            private readonly CompositeDisposable _disposables = new CompositeDisposable();
            private readonly Action _action;
            private readonly Subject<bool> _subject;
            private readonly ObservableWithValue<bool> _isEnabled;

            public IObservableWithValue<bool> IsEnabled { get { return _isEnabled; } }

            internal Command(Action action, bool isEnalbed)
            {
                _action = action;
                _subject = new Subject<bool>();
                _subject.OnNext(isEnalbed);
                _isEnabled = new ObservableWithValue<bool>(_subject, isEnalbed);

                _disposables.Add(_isEnabled);
                _disposables.Add(_subject);
            }

            public void OnNext(bool value)
            {
                _subject.OnNext(value);
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

        protected CompositeDisposable Disposables { get; } = new CompositeDisposable();

        protected IActiveViewManager ActiveViewManager { get; }

        protected readonly Command _copy;
        public ICommand Copy { get { return _copy; } }

        protected readonly Command _paste;
        public ICommand Paste { get { return _paste; } }

        public ContentBaseViewModel(IActiveViewManager activeViewManager)
        {
            ActiveViewManager = activeViewManager;

            _copy = Init(new Command(CopyFunction, false));
            _paste = Init(new Command(PasteFunction, false));
        }

        public virtual void Activate()
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

        private Command Init(Command command)
        {
            Disposables.Add(command);
            return command;
        }
    }
}
