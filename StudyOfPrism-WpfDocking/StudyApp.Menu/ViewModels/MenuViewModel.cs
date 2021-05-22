using Design.StudyApp.ActiveViewManager;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Diagnostics;
using System.Reactive.Disposables;

namespace StudyApp.Menu.ViewModels
{
    public class MenuViewModel : BindableBase, IDisposable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        private readonly IActiveViewManager _activeViewManager;

        public ReadOnlyReactivePropertySlim<bool> IsCopyEnabled { get; }

        public ReactiveCommand CopyCommand { get; } = new ReactiveCommand();

        public ReadOnlyReactivePropertySlim<bool> IsPasteEnabled { get; }

        public ReactiveCommand PasteCommand { get; } = new ReactiveCommand();

        public MenuViewModel(IActiveViewManager activeViewManager)
        {
            _activeViewManager = activeViewManager;

            IsCopyEnabled = Init(_activeViewManager.ActiveView.Copy, CopyCommand, _disposables);
            IsPasteEnabled = Init(_activeViewManager.ActiveView.Paste, PasteCommand, _disposables);
        }

        private static ReadOnlyReactivePropertySlim<bool> Init(ICommand command, ReactiveCommand reactiveCommand, CompositeDisposable disposables)
        {
            reactiveCommand.AddTo(disposables);
            reactiveCommand.Subscribe(() =>
            {
                command.Execute();
            });
            return command.IsEnabled.ToReadOnlyReactivePropertySlim().AddTo(disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
