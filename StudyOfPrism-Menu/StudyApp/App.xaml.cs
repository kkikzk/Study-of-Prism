using Prism.Ioc;
using Prism.Modularity;
using StudyApp.Manu;
using StudyApp.Pane.Main;
using StudyApp.Pane.ProjectTree;
using StudyApp.Pane.Property;
using StudyApp.StatusBar;
using StudyApp.Views;
using System.Windows;

namespace StudyApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var menu2 = new MenuItemData("メニュー2(_B)");
            var menu3 = new MenuItemData("メニュー3(_C)", new IMenuItemData[0], false, Visibility.Visible);
            var menu1 = new MenuItemData("メニュー1(_A)", new IMenuItemData[] { menu2, menu3 }, true, Visibility.Visible);

            var menu5 = new MenuItemData("メニュー5(_E)");
            var menu6 = new MenuItemData("メニュー6(_F)");
            var menu4 = new MenuItemData("メニュー4(_D)", new IMenuItemData[] { menu5, menu6 }, true, Visibility.Visible);

            IMenuData menuData = new MenuData(new IMenuItemData[] { menu1, menu4 });

            containerRegistry.RegisterInstance(menuData);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MenuModule>();
            moduleCatalog.AddModule<StatusBarModule>();
            moduleCatalog.AddModule<ProjectTreeModule>();
            moduleCatalog.AddModule<PropertyModule>();
            moduleCatalog.AddModule<MainModule>();
        }
    }
}
