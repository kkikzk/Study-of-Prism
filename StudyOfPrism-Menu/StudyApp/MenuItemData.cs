using StudyApp.Manu;

namespace StudyApp
{
    public class MenuItemData : IMenuItemData
    {
        public string DisplayName { get; }

        public IMenuItemData[] Children { get; }

        public MenuItemData(string displayName)
            : this(displayName, new IMenuItemData[0])
        {
        }

        public MenuItemData(string displayName, IMenuItemData[] children)
        {
            DisplayName = displayName;
            Children = children;
        }
    }
}
