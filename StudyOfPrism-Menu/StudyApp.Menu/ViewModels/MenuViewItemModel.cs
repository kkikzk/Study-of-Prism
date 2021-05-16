using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;

namespace StudyApp.Manu.ViewModels
{
    internal class MenuViewItemModel : BindableBase, IDisposable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public ReadOnlyReactivePropertySlim<string> DisplayName { get; }

        public ReadOnlyReactiveCollection<MenuViewItemModel> Children { get; }

        public MenuViewItemModel(IMenuItemData data)
        {
            DisplayName = new ReactiveProperty<string>(data.DisplayName).ToReadOnlyReactivePropertySlim().AddTo(_disposables);

            var children = new ObservableCollection<MenuViewItemModel>();
            foreach (var child in data.Children)
            {
                children.Add(new MenuViewItemModel(child));
            }

            Children = children.ToReadOnlyReactiveCollection().AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
