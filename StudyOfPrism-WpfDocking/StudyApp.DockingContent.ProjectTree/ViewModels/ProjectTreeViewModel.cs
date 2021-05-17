using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;

namespace StudyApp.DockingContent.ProjectTree.ViewModels
{
    internal class ProjectTreeViewModel : BindableBase, IDisposable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        private readonly IProjectTreeData _data;

        public ReactiveCollection<ProjectTreeItemViewModelBase> Nodes { get; }

        public ProjectTreeViewModel(IProjectTreeData data)
        {
            _data = data;

            var col = new ReactiveCollection<ProjectTreeItemViewModelBase>();
            col.Add(new RootProjectTreeItemViewModel(data.RootNode));
            Nodes = col.AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }

    internal class ProjectTreeItemViewModelBase : BindableBase, IDisposable
    {
        protected readonly CompositeDisposable _disposables = new CompositeDisposable();

        public ReadOnlyReactivePropertySlim<string> DisplayName { private set; get; }

        public ReadOnlyReactivePropertySlim<bool> IsExpanded { private set; get; }

        public ReactiveCollection<ProjectTreeItemViewModelBase> Nodes { protected set; get; }

        protected ProjectTreeItemViewModelBase(INodeDataBase data)
        {
            DisplayName = new ReactiveProperty<string>(data.DisplayName.Observable, data.DisplayName.Default)
                .ToReadOnlyReactivePropertySlim().AddTo(_disposables);
            IsExpanded = new ReactiveProperty<bool>(data.IsExpanded.Observable, data.IsExpanded.Default)
                .ToReadOnlyReactivePropertySlim().AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }

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

    internal class ProgramProjectTreeItemViewModel : ProjectTreeItemViewModelBase
    {
        public ProgramProjectTreeItemViewModel(IProgramNodeData data)
            : base(data)
        {
            Nodes = new ReactiveCollection<ProjectTreeItemViewModelBase>().AddTo(_disposables);
        }
    }
}
