using System;

namespace Design.StudyApp
{
    public interface IObservableEx<T>
    {
        IObservable<T> Observable { get; }

        T Default { get; }
    }
}
