using System;

namespace Design.StudyApp
{
    public interface IObservableWithDefault<T>
    {
        IObservable<T> Observable { get; }

        T Default { get; }
    }
}
