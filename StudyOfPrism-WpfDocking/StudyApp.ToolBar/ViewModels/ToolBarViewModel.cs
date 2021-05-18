using Prism.Mvvm;
using System;
using System.Reactive.Disposables;

namespace StudyApp.ToolBar.ViewModels
{
    public class ToolBarViewModel : BindableBase, IDisposable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public ToolBarViewModel()
        {
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
