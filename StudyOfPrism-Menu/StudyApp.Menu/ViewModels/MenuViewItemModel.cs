using Prism.Events;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Windows;

namespace StudyApp.Manu.ViewModels
{
    internal class MenuViewItemModel : BindableBase, IDisposable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        private readonly IEventAggregator _eventAggregator;
        private readonly IMenuItemData _data;

        public ReadOnlyReactivePropertySlim<string> DisplayName { get; }

        public ReadOnlyReactivePropertySlim<bool> IsEnabled { get; }

        public ReadOnlyReactivePropertySlim<Visibility> IsVisible { get; }

        public ReadOnlyReactiveCollection<MenuViewItemModel> Children { get; }

        public ReactiveCommand Command { get; } = new ReactiveCommand();

        public MenuViewItemModel(IEventAggregator eventAggrigator, IMenuItemData data)
        {
            _eventAggregator = eventAggrigator;
            _data = data;

            DisplayName = new ReactiveProperty<string>(data.DisplayName).ToReadOnlyReactivePropertySlim().AddTo(_disposables);
            IsEnabled = new ReactiveProperty<bool>(data.IsEnabled.Observable, data.IsEnabled.Default).ToReadOnlyReactivePropertySlim().AddTo(_disposables);
            IsVisible = new ReactiveProperty<Visibility>(data.Visibility.Observable, data.Visibility.Default).ToReadOnlyReactivePropertySlim().AddTo(_disposables);

            var children = new ObservableCollection<MenuViewItemModel>();
            foreach (var child in data.Children)
            {
                children.Add(new MenuViewItemModel(eventAggrigator, child));
            }

            Children = children.ToReadOnlyReactiveCollection().AddTo(_disposables);
            Command.Subscribe(CommandImpl).AddTo(_disposables);
        }

        private void CommandImpl()
        {

        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
