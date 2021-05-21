using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using StudyApp.DockingContent.Base.ViewModels;
using StudyApp.DockingContent.Base.Views;
using System;
using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Controls;

namespace StudyApp.DockingContent.ViewModels
{
    internal class OutputDockItemViewModel : BindableBase, IDisposable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public ReactiveCommand<RoutedEventArgs> OnGotFocus { get; } = new ReactiveCommand<RoutedEventArgs>();

        internal OutputDockItemViewModel()
        {
            OnGotFocus.AddTo(_disposables);
            OnGotFocus.Subscribe(_ =>
            {
                var originalSource = (ContentControl)_?.OriginalSource;
                var content = (ContentBase)originalSource?.Content;
                var dataContext = (ContentBaseViewModel)content?.DataContext;
                dataContext?.Activate();
            });
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
