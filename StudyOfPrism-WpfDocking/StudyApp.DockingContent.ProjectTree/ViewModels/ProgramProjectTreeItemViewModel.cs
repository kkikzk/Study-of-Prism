using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace StudyApp.DockingContent.ProjectTree.ViewModels
{
    internal class ProgramProjectTreeItemViewModel : ProjectTreeItemViewModelBase
    {
        public ProgramProjectTreeItemViewModel(IProgramNodeData data)
            : base(data)
        {
            Nodes = new ReactiveCollection<ProjectTreeItemViewModelBase>().AddTo(_disposables);
        }
    }
}
