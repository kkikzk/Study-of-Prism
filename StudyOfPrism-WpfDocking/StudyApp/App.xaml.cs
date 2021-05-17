using Design.StudyApp;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using StudyApp.DockingContent;
using StudyApp.DockingContent.Output;
using StudyApp.DockingContent.ProjectTree;
using StudyApp.DockingContent.ProjectTree.ViewModels;
using StudyApp.DockingContent.Property;
using StudyApp.Views;
using System;
using System.Reactive.Subjects;
using System.Windows;

namespace StudyApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly StudyAppData _data = new StudyAppData();

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<IProjectTreeData>(_data.ProjectTreeData);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<DockingContentModule>();
            moduleCatalog.AddModule<ProjectTreeModule>();
            moduleCatalog.AddModule<OutputModule>();
            moduleCatalog.AddModule<PropertyModule>();
        }
    }

    public class StudyAppData
    {
        public ProjectTreeData ProjectTreeData { get; }

        public StudyAppData()
        {
            var main = new ProgramNodeData("Main", true);
            var sub = new ProgramNodeData("Sub", true);
            var programRootNode = new ProgramRootNodeData("プログラム", true, new[] { main, sub });
            var controller = new ControllerNodeData("コントローラ1: ORiN3.Provider.DNWA.Dummy", true, programRootNode);
            var root = new RootNodeData("プロジェクト", true, new[] { controller });
            ProjectTreeData = new ProjectTreeData(root);
        }
    }

    public class ObservableWithDefault<T> : IObservableWithDefault<T>
    {
        public IObservable<T> Observable { private set; get; }

        public T Default { private set; get; }

        public ObservableWithDefault(T value)
        {
            Observable = new Subject<T>();
            Default = value;
        }
    }

    public class NodeDataBase : BindableBase, INodeDataBase
    {
        public IObservableWithDefault<string> DisplayName { private set; get; }

        public IObservableWithDefault<bool> IsExpanded { private set; get; }

        protected NodeDataBase(string displayName, bool isExpanded)
        {
            DisplayName = new ObservableWithDefault<string>(displayName);
            IsExpanded = new ObservableWithDefault<bool>(isExpanded);
        }
    }

    public class ProjectTreeData : IProjectTreeData
    {
        public IRootNodeData RootNode { get; }

        public ProjectTreeData(IRootNodeData rootNode)
        {
            RootNode = rootNode;
        }
    }

    public class RootNodeData : NodeDataBase, IRootNodeData
    {
        public IControllerNodeData[] ControllerNodes { private set; get; }

        public RootNodeData(string displayName, bool isExpanded, IControllerNodeData[] controllerNodes)
            : base(displayName, isExpanded)
        {
            ControllerNodes = controllerNodes;
        }
    }

    public class ControllerNodeData : NodeDataBase, IControllerNodeData
    {
        public IProgramRootNodeData ProgramRootNode { private set; get; }

        public ControllerNodeData(string displayName, bool isExpanded, IProgramRootNodeData programRootNodeData)
            : base(displayName, isExpanded)
        {
            ProgramRootNode = programRootNodeData;
        }
    }

    public class ProgramRootNodeData : NodeDataBase, IProgramRootNodeData
    {

        public IProgramNodeData[] ProgramNodes { private set; get; }

        public ProgramRootNodeData(string displayName, bool isExpanded, IProgramNodeData[] programRootNodeData)
            : base(displayName, isExpanded)
        {
            ProgramNodes = programRootNodeData;
        }
    }

    public class ProgramNodeData : NodeDataBase, IProgramNodeData
    {
        public ProgramNodeData(string displayName, bool isExpanded)
            : base(displayName, isExpanded)
        {
        }
    }
}
