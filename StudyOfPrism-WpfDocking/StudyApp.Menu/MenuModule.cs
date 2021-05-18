using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace StudyApp.Menu
{
    public class MenuModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(nameof(Views.Menu), typeof(Views.Menu));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}