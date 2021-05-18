using Design.StudyApp;
using Design.StudyApp.ActiveViewManager;
using System;
using System.Reactive.Subjects;

namespace StudyApp.Model
{
    public class ActiveViewManager : IActiveViewManager
    {
        internal class DummyView : IActiveView
        {
            internal class ObservableWithDefault<T> : IObservableWithDefault<T>
            {
                public IObservable<T> Observable { get; } = new Subject<T>();

                public T Default { get; } = default;
            }

            internal class Command : ICommand
            {
                public IObservableWithDefault<bool> IsEnabled { get; } = new ObservableWithDefault<bool>();

                public void Execute()
                {
                    throw new System.NotImplementedException();
                }
            }

            public ICommand Copy { get; } = new Command();

            public ICommand Paste { get; } = new Command();
        }

        public IActiveView ActiveView { private set; get; } = new DummyView();

        public void Activate(IActiveView target)
        {
            ActiveView = target;
        }
    }
}
