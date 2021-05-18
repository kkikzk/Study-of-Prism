using Reactive.Bindings;

namespace StudyApp.DockingContent.ProjectTree.ViewModels
{
    internal class ProgramRootProjectTreeItemViewModel : ProjectTreeItemViewModelBase
    {
        public ProgramRootProjectTreeItemViewModel(IProgramRootNodeData data)
            : base(data)
        {
            Nodes = new ReactiveCollection<ProjectTreeItemViewModelBase>();
            foreach (var it in data.ProgramNodes)
            {
                Nodes.Add(new ProgramProjectTreeItemViewModel(it));
            }
        }
    }
}
