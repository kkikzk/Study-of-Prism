namespace Design.StudyApp.ActiveViewManager
{
    public interface IActiveViewManager
    {
        IActiveView ActiveView { get; }

        void Activate(IActiveView target);
    }
}
