using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Reactive.Disposables;

namespace StudyApp.DockingContent.ProjectTree.ViewModels
{
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
}
