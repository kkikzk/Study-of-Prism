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

        public override void Activate()
        {
            base.Activate();
            _copy.OnNext(true);
            _paste.OnNext(true);
        }

        protected override void CopyFunction()
        {
        }

        protected override void PasteFunction()
        {
        }
    }
}
