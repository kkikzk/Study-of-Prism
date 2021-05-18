namespace Design.StudyApp.ActiveViewManager
{
    public interface IActiveView
    {
        ICommand Copy { get; }

        ICommand Paste { get; }
    }

    public interface ICommand
    {
        IObservableWithDefault<bool> IsEnabled { get; }

        void Execute();
    }
}
