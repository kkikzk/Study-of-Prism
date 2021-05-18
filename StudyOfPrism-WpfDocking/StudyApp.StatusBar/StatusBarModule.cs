using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace StudyApp.StatusBar
{
    public class StatusBarModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(nameof(Views.StatusBar), typeof(Views.StatusBar));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}