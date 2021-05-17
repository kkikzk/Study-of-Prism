using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace StudyApp.Pane.Main
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager?.RegisterViewWithRegion(nameof(Views.Main), typeof(Views.Main));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}