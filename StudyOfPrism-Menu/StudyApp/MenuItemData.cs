using Design.StudyApp;
using StudyApp.Manu;
using System.Reactive.Subjects;
using System.Windows;

namespace StudyApp
{
    public class MenuItemData : IMenuItemData
    {
        private readonly Subject<bool> _isEnabled;
        private readonly Subject<Visibility> _visibility;

        public string DisplayName { get; }

        public IMenuItemData[] Children { get; }

        public IObservableWithDefault<bool> IsEnabled { get; }

        public IObservableWithDefault<Visibility> Visibility { get; }

        public MenuItemData(string displayName)
            : this(displayName, new IMenuItemData[0], true, System.Windows.Visibility.Visible)
        {
        }

        public MenuItemData(string displayName, IMenuItemData[] children, bool isEnabled, Visibility visibility)
        {
            DisplayName = displayName;
            Children = children;

            _isEnabled = new Subject<bool>();
            _isEnabled.OnNext(isEnabled);
            IsEnabled = new ObservableWithDefault<bool>(_isEnabled, isEnabled);

            _visibility = new Subject<Visibility>();
            _visibility.OnNext(visibility);
            Visibility = new ObservableWithDefault<Visibility>(_visibility, visibility);
        }
    }
}
