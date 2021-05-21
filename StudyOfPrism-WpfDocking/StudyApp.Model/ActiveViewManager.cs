using Design.StudyApp.ActiveViewManager;
using System;
using System.Reactive.Disposables;
using System.Reactive.Subjects;

namespace StudyApp.Model
{
    public class ActiveViewManager : IActiveViewManager
    {
        private readonly HandOverView _handOverView;

        internal class HandOverView : IActiveView
        {
            private readonly CompositeDisposable _disposables = new CompositeDisposable();
            private IActiveView _view;

            internal class Command : ICommand, IDisposable
            {
                private readonly CompositeDisposable _disposables = new CompositeDisposable();
                private Action _action;
                private readonly Subject<bool> _isEnalbed;
                private IDisposable _remover;

                public ISubject<bool> IsEnabled { get { return _isEnalbed; } }

                internal Command(Action action, ISubject<bool> isEnabled)
                {
                    _isEnalbed = new Subject<bool>();
                    _disposables.Add(_isEnalbed);
                    _remover = isEnabled.Subscribe(_isEnalbed);
                    _action = action;
                }

                internal void Update(Action action, ISubject<bool> isEnabled)
                {
                    _remover.Dispose();
                    _remover = isEnabled.Subscribe(_isEnalbed);
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

                public Command AddTo(CompositeDisposable disposables)
                {
                    disposables.Add(this);
                    return this;
                }
            }

            private readonly Command _copy;
            public ICommand Copy { get { return _copy; } }

            private readonly Command _paste;
            public ICommand Paste { get { return _paste; } }

            internal HandOverView()
            {
                var subject = new Subject<bool>();
                subject.OnNext(true);
                _copy = new Command(() => { }, subject);
                _paste = new Command(() => { }, subject);
            }

            internal void SetView(IActiveView view)
            {
                _view = view;
                _copy.Update(() => { _view.Copy.Execute(); }, _view.Copy.IsEnabled);
                _paste.Update(() => { _view.Paste.Execute(); }, _view.Paste.IsEnabled);
            }

            public void Dispose()
            {
                _disposables.Dispose();
            }
        }

        public IActiveView ActiveView { get { return _handOverView; } }

        public ActiveViewManager()
        {
            _handOverView = new HandOverView();
        }

        public void Activate(IActiveView target)
        {
            _handOverView.SetView(target);
        }
    }
}
