using System.Reactive.Subjects;

namespace Design.StudyApp.ActiveViewManager
{
    public interface IActiveView
    {
        ICommand Copy { get; }

        ICommand Paste { get; }
    }

    public interface ICommand
    {
        ISubject<bool> IsEnabled { get; }

        void Execute();
    }
}
