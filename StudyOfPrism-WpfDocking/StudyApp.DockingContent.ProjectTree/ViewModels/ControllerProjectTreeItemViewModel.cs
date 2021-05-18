using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace StudyApp.DockingContent.ProjectTree.ViewModels
{
    internal class ControllerProjectTreeItemViewModel : ProjectTreeItemViewModelBase
    {
        public ControllerProjectTreeItemViewModel(IControllerNodeData data)
            : base(data)
        {
            var col = new ReactiveCollection<ProjectTreeItemViewModelBase>();
            col.Add(new ProgramRootProjectTreeItemViewModel(data.ProgramRootNode));
            Nodes = col.AddTo(_disposables);
        }
    }
}
