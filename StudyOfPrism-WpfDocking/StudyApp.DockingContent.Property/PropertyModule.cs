using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace StudyApp.DockingContent.Property
{
    public class PropertyModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(nameof(Views.Property), typeof(Views.Property));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}