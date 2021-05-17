using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace StudyApp.DockingContent.Output
{
    public class OutputModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(nameof(Views.Output), typeof(Views.Output));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}