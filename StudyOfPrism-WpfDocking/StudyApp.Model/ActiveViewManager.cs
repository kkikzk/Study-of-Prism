using Design.StudyApp;
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
                private readonly Subject<bool> _subject = new Subject<bool>();
                private readonly ObservableWithValue<bool> _isEnalbed;
                private Action _action;
                private IDisposable _remover;

                public IObservableWithValue<bool> IsEnabled { get { return _isEnalbed; } }

                internal Command(Action action, IObservable<bool> isEnabled, bool value)
                {
                    _subject.OnNext(value);
                    _remover = isEnabled.Subscribe(_subject);
                    _isEnalbed = new ObservableWithValue<bool>(_subject, value);
                    _action = action;

                    _disposables.Add(_isEnalbed);
                    _disposables.Add(_subject);
                }

                internal void Update(Action action, IObservableWithValue<bool> isEnabled)
                {
                    _remover.Dispose();
                    var currentValue = _isEnalbed.Value;
                    _remover = isEnabled.Observable.Subscribe(_subject);
                    if (currentValue != isEnabled.Value)
                    {
                        _subject.OnNext(isEnabled.Value);
                    }
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

            private readonly Command _copy;
            public ICommand Copy { get { return _copy; } }

            private readonly Command _paste;
            public ICommand Paste { get { return _paste; } }

            internal HandOverView()
            {
                var defaultValue = false;
                var subject = new Subject<bool>();
                _disposables.Add(subject);
                subject.OnNext(defaultValue);
                _copy = new Command(() => { }, subject, defaultValue);
                _paste = new Command(() => { }, subject, defaultValue);
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
