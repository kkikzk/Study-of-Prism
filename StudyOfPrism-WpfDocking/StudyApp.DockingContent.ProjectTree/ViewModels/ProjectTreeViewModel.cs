using Design.StudyApp.ActiveViewManager;
using Design.StudyApp.ProjectContentManager;
using Reactive.Bindings;
using StudyApp.DockingContent.Base.ViewModels;

namespace StudyApp.DockingContent.ProjectTree.ViewModels
{
    internal class ProjectTreeViewModel : ContentBaseViewModel
    {
        private readonly IProjectTreeData _data;
        private readonly IProjectContentManager _projectContentManager;

        public ReactiveCollection<IProjectTreeData> Children { get { return _data.Children; } }

        public ProjectTreeViewModel(IProjectTreeData data, IActiveViewManager activeViewManager, IProjectContentManager projectContentManager)
            : base(activeViewManager)
        {
            _data = data;
            Disposables.Add(_data);
            _projectContentManager = projectContentManager;
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
            _projectContentManager.Execute();
        }
    }
}
