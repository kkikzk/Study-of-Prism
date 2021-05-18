using Design.StudyApp.ActiveViewManager;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
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

            IsCopyEnabled = new ReactiveProperty<bool>(
                _activeViewManager.ActiveView.Copy.IsEnabled.Observable, _activeViewManager.ActiveView.Copy.IsEnabled.Default)
                .ToReadOnlyReactivePropertySlim().AddTo(_disposables);

            CopyCommand.Subscribe(() =>
            {
                _activeViewManager.ActiveView.Copy.Execute();
            });

            IsPasteEnabled = new ReactiveProperty<bool>(
                _activeViewManager.ActiveView.Paste.IsEnabled.Observable, _activeViewManager.ActiveView.Paste.IsEnabled.Default)
                .ToReadOnlyReactivePropertySlim().AddTo(_disposables);

            PasteCommand.Subscribe(() =>
            {
                _activeViewManager.ActiveView.Paste.Execute();
            });
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
