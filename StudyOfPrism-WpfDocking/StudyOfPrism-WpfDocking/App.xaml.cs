using Prism.Ioc;
using StudyOfPrism_WpfDocking.Views;
using System.Windows;

namespace StudyOfPrism_WpfDocking
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

        }
    }
}
