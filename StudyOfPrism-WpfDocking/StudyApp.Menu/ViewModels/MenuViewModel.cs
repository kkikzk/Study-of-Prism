using Prism.Mvvm;
using System;
using System.Reactive.Disposables;

namespace StudyApp.Menu.ViewModels
{
    public class MenuViewModel : BindableBase, IDisposable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public MenuViewModel()
        {
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
