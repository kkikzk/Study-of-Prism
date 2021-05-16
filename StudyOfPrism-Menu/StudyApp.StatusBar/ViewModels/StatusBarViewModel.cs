using Prism.Events;
using Prism.Mvvm;
using System;
using System.Reactive.Disposables;

namespace StudyApp.StatusBar.ViewModels
{
    public class StatusBarViewModel : BindableBase, IDisposable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public StatusBarViewModel(IEventAggregator eventAggrigator)
        {
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
