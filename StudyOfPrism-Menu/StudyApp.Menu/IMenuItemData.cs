using Design.StudyApp;
using System.Windows;

namespace StudyApp.Manu
{
    public interface IMenuItemData
    {
        string DisplayName { get; }

        IMenuItemData[] Children { get; }

        IObservableEx<bool> IsEnabled { get; }

        IObservableEx<Visibility> Visibility { get; }
    }
}
