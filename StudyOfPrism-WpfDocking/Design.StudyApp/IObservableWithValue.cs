using System;

namespace Design.StudyApp
{
    public interface IObservableWithValue<out T>
    {
        IObservable<T> Observable { get; }

        T Value { get; }
    }
}
