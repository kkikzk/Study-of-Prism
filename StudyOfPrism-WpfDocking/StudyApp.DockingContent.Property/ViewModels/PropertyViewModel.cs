using Prism.Mvvm;
using System;
using System.Reactive.Disposables;

namespace StudyApp.DockingContent.Property.ViewModels
{
    internal class PropertyViewModel : BindableBase, IDisposable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public PropertyViewModel()
        {
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
