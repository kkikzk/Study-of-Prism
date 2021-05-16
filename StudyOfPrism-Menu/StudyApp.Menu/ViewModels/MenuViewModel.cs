using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;

namespace StudyApp.Manu.ViewModels
{
    internal class MenuViewModel : BindableBase, IDisposable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public ReadOnlyReactiveCollection<MenuViewItemModel> MenuNodes { get; }

        public MenuViewModel(IMenuData data)
        {
            var col = new ObservableCollection<MenuViewItemModel>();
            foreach (var child in data.Children)
            {
                col.Add(new MenuViewItemModel(child));
            }
            MenuNodes = col.ToReadOnlyReactiveCollection().AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
