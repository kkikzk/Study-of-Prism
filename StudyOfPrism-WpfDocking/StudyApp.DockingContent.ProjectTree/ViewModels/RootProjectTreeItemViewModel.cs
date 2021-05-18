using Reactive.Bindings;

namespace StudyApp.DockingContent.ProjectTree.ViewModels
{
    internal class RootProjectTreeItemViewModel : ProjectTreeItemViewModelBase
    {
        public RootProjectTreeItemViewModel(IRootNodeData data)
            : base(data)
        {
            Nodes = new ReactiveCollection<ProjectTreeItemViewModelBase>();
            foreach (var it in data.ControllerNodes)
            {
                Nodes.Add(new ControllerProjectTreeItemViewModel(it));
            }
        }
    }
}
