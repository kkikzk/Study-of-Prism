using StudyApp.Manu;

namespace StudyApp
{
    public class MenuData : IMenuData
    {
        public IMenuItemData[] Children { get; }

        public MenuData(IMenuItemData[] children)
        {
            Children = children;
        }
    }
}
