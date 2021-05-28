using Design.StudyApp.ActiveViewManager;
using Design.StudyApp.DockingContent;
using Prism.Events;
using StudyApp.DockingContent.Base.ViewModels;
using System.Reactive.Disposables;

namespace StudyApp.DockingContent.Output.ViewModels
{
    public class OutputViewModel : ContentBaseViewModel
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public OutputViewModel(IActiveViewManager activeViewManager, IEventAggregator eventAggregator)
            : base(activeViewManager)
        {
            eventAggregator.GetEvent<OutputDockItemSelectedEvent>().Subscribe(OutputDockItemSelected, ThreadOption.UIThread);
        }

        private void OutputDockItemSelected()
        {
            Activate();
        }

        public override void Activate()
        {
            base.Activate();
            _copy.OnNext(false);
            _paste.OnNext(false);
        }

        protected override void CopyFunction()
        {
        }

        protected override void PasteFunction()
        {
        }
    }
}
