using Prism.Mvvm;
using System;
using System.Reactive.Disposables;

namespace StudyApp.DockingContent.ViewModels
{
    internal class DockingContentViewModel : BindableBase, IDisposable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public DockingContentViewModel()
        {
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
