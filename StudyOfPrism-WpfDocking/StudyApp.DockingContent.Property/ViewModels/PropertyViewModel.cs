using Design.StudyApp.ActiveViewManager;
using StudyApp.DockingContent.Base.ViewModels;
using System.Reactive.Disposables;

namespace StudyApp.DockingContent.Property.ViewModels
{
    internal class PropertyViewModel : ContentBaseViewModel
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public PropertyViewModel(IActiveViewManager activeViewManager)
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
