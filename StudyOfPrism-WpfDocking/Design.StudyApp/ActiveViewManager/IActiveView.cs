namespace Design.StudyApp.ActiveViewManager
{
    public interface IActiveView
    {
        ICommand Copy { get; }

        ICommand Paste { get; }
    }

    public interface ICommand
    {
        IObservableWithValue<bool> IsEnabled { get; }

        void Execute();
    }
}
