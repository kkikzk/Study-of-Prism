namespace StudyApp.Manu
{
    public interface IMenuItemData
    {
        string DisplayName { get; }

        IMenuItemData[] Children { get; }
    }
}
