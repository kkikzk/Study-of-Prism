using Design.StudyApp;
using System.Windows;

namespace StudyApp.Manu
{
    public interface IMenuItemData
    {
        string DisplayName { get; }

        IMenuItemData[] Children { get; }

        IObservableWithDefault<bool> IsEnabled { get; }

        IObservableWithDefault<Visibility> Visibility { get; }
    }
}
