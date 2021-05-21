using Design.StudyApp.ActiveViewManager;
using StudyApp.DockingContent.Base.ViewModels;
using System.Reactive.Disposables;

namespace StudyApp.DockingContent.Output.ViewModels
{
    public class OutputViewModel : ContentBaseViewModel
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public OutputViewModel(IActiveViewManager activeViewManager)
            : base(activeViewManager)
        {
        }

        protected override void CopyFunction()
        {
        }

        protected override void PasteFunction()
        {
        }
    }
}
