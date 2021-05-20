using Reactive.Bindings;
using System;

namespace StudyApp.DockingContent.ProjectTree.ViewModels
{
    public interface IProjectTreeData : INodeDataBase, IDisposable
    {
        ReactiveCollection<IProjectTreeData> Children { get; }
    }

    public interface INodeDataBase : IDisposable
    {
        ReactiveProperty<string> DisplayName { get; }

        ReactiveProperty<bool> IsExpanded { get; }
    }
}
