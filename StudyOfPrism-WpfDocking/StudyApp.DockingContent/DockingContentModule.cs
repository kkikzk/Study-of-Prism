using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace StudyApp.DockingContent
{
    public class DockingContentModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(nameof(Views.DockingContent), typeof(Views.DockingContent));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}