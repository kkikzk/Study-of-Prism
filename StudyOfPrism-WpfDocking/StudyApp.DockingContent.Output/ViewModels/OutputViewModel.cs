using Prism.Mvvm;
using System;
using System.Reactive.Disposables;

namespace StudyApp.DockingContent.Output.ViewModels
{
    public class OutputViewModel : BindableBase, IDisposable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public OutputViewModel()
        {
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
