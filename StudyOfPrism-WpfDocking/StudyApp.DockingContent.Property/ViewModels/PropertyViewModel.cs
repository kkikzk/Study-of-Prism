using Design.StudyApp.ActiveViewManager;
using Design.StudyApp.DockingContent;
using Prism.Events;
using StudyApp.DockingContent.Base.ViewModels;
using System.Reactive.Disposables;

namespace StudyApp.DockingContent.Property.ViewModels
{
    internal class PropertyViewModel : ContentBaseViewModel
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public PropertyViewModel(IActiveViewManager activeViewManager, IEventAggregator eventAggregator)
            : base(activeViewManager)
        {
            eventAggregator.GetEvent<PropertyDockItemSelectedEvent>().Subscribe(PropertyDockItemSelected, ThreadOption.UIThread);
        }

        private void PropertyDockItemSelected()
        {
            Activate();
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
