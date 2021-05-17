using Design.StudyApp;
using System.ComponentModel;

namespace StudyApp.DockingContent.ProjectTree.ViewModels
{
    public interface IProjectTreeData
    {
        IRootNodeData RootNode { get; }
    }

    public interface INodeDataBase : INotifyPropertyChanged
    {
        IObservableWithDefault<string> DisplayName { get; }

        IObservableWithDefault<bool> IsExpanded { get; }
    }

    public interface IRootNodeData : INodeDataBase
    {
        IControllerNodeData[] ControllerNodes { get; }
    }

    public interface IControllerNodeData : INodeDataBase
    {
        IProgramRootNodeData ProgramRootNode { get; }
    }

    public interface IProgramRootNodeData : INodeDataBase
    {
        IProgramNodeData[] ProgramNodes { get; }
    }

    public interface IProgramNodeData : INodeDataBase
    {
    }
}
