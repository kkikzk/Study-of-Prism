using Design.StudyApp;
using System;

namespace StudyApp
{
    public class ObservableWithDefault<T> : IObservableWithDefault<T>
    {
        public IObservable<T> Observable { get; }

        public T Default { get; }

        public ObservableWithDefault(IObservable<T> observable, T defaultValue)
        {
            Observable = observable;
            Default = defaultValue;
        }
    }
}
