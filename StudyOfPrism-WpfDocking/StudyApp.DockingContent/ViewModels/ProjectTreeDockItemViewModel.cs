using Prism.Events;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Reactive.Disposables;
using System.Windows;

namespace StudyApp.DockingContent.ViewModels
{
    internal class ProjectTreeDockItemViewModel : BindableBase, IDisposable
    {
        internal class ProjectTreeDockItemSelectedEvent : PubSubEvent
        {
        }

        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public IEventAggregator EventAggregator { get; }

        public ReactiveCommand<RoutedEventArgs> OnGotFocus { get; } = new ReactiveCommand<RoutedEventArgs>();

        internal ProjectTreeDockItemViewModel(IEventAggregator ea)
        {
            EventAggregator = ea;
            
            OnGotFocus.AddTo(_disposables);
            OnGotFocus.Subscribe(_ =>
            {
                EventAggregator.GetEvent<ProjectTreeDockItemSelectedEvent>().Publish();
            });
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
