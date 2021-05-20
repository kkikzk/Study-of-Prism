using Design.StudyApp;
using Design.StudyApp.ActiveViewManager;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using StudyApp.DockingContent;
using StudyApp.DockingContent.Output;
using StudyApp.DockingContent.ProjectTree;
using StudyApp.DockingContent.ProjectTree.ViewModels;
using StudyApp.DockingContent.Property;
using StudyApp.Menu;
using StudyApp.Model;
using StudyApp.StatusBar;
using StudyApp.ToolBar;
using StudyApp.Views;
using System;
using System.Reactive.Disposables;
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
            containerRegistry.RegisterInstance(_data.ActiveViewManager);
            containerRegistry.RegisterInstance(_data.ProjectTreeData);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<DockingContentModule>();
            moduleCatalog.AddModule<ProjectTreeModule>();
            moduleCatalog.AddModule<OutputModule>();
            moduleCatalog.AddModule<PropertyModule>();
            moduleCatalog.AddModule<MenuModule>();
            moduleCatalog.AddModule<ToolBarModule>();
            moduleCatalog.AddModule<StatusBarModule>();
        }
    }

    public class StudyAppData
    {
        public IActiveViewManager ActiveViewManager { get; } = new ActiveViewManager();

        public IProjectTreeData ProjectTreeData { get; }

        public StudyAppData()
        {
            var main = new ProjectTreeData("Main", true);
            var sub = new ProjectTreeData("Sub", true);
            var programRootNode = new ProjectTreeData("プログラム", true, main, sub);
            var controller = new ProjectTreeData("コントローラ1: ORiN3.Provider.DNWA.Dummy", true, programRootNode);
            var root = new ProjectTreeData("プロジェクト", true, controller);
            ProjectTreeData = new ProjectTreeData("Root", true, root);
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

    public class ProjectTreeData : IProjectTreeData
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public ReactiveCollection<IProjectTreeData> Children { get; }

        public ReactiveProperty<string> DisplayName { get; }

        public ReactiveProperty<bool> IsExpanded { get; }

        public ProjectTreeData(string name, bool isExpanded)
            : this(name, isExpanded, new ReactiveCollection<IProjectTreeData>())
        {
        }

        public ProjectTreeData(string name, bool isExpanded, params IProjectTreeData[] data)
            : this(name, isExpanded)
        {
            foreach (var it in data)
            {
                Children.Add(it);
            }
        }

        public ProjectTreeData(string name, bool isExpanded, ReactiveCollection<IProjectTreeData> children)
        {
            DisplayName = new ReactiveProperty<string>(name).AddTo(_disposables);
            IsExpanded = new ReactiveProperty<bool>(isExpanded).AddTo(_disposables);
            Children = children;
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
