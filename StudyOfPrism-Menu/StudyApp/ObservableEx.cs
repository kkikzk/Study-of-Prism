using Design.StudyApp;
using System;

namespace StudyApp
{
    public class ObservableEx<T> : IObservableEx<T>
    {
        public IObservable<T> Observable { get; }

        public T Default { get; }

        public ObservableEx(IObservable<T> observable, T defaultValue)
        {
            Observable = observable;
            Default = defaultValue;
        }
    }
}
