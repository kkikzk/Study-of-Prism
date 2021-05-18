using Design.StudyApp;
using Design.StudyApp.ActiveViewManager;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Reactive.Disposables;
using System.Reactive.Subjects;

namespace StudyApp.DockingContent.ProjectTree.ViewModels
{
    internal class ProjectTreeViewModel : BindableBase, IDisposable, IActiveView
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        private readonly IProjectTreeData _data;
        private readonly IActiveViewManager _activeViewManager;

        public ReactiveCollection<ProjectTreeItemViewModelBase> Nodes { get; }

        public ICommand Copy { get; }

        public ICommand Paste { get; }

        public ProjectTreeViewModel(IProjectTreeData data, IActiveViewManager activeViewManager)
        {
            _data = data;
            var col = new ReactiveCollection<ProjectTreeItemViewModelBase>();
            col.Add(new RootProjectTreeItemViewModel(_data.RootNode));
            Nodes = col.AddTo(_disposables);

            _activeViewManager = activeViewManager;
            _activeViewManager.Activate(this);

            Copy = new Command();
            Paste = new Command();
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }

    internal class Command : ICommand
    {
        public IObservableWithDefault<bool> IsEnabled { get; }

        public Command()
        {
            var temp = new Subject<bool>();
            IsEnabled = new ObservableWithDefault<bool>(temp, true);
        }

        public void Execute()
        {

        }
    }

    internal class ObservableWithDefault<T> : IObservableWithDefault<T>
    {
        public IObservable<T> Observable { get; }

        public T Default { get; }

        public ObservableWithDefault(IObservable<T> observable, T defaultValue)
        {
            Observable = observable;
            Default = defaultValue;
        }
    }
}
