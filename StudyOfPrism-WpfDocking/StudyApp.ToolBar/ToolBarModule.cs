using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace StudyApp.ToolBar
{
    public class ToolBarModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(nameof(Views.ToolBar), typeof(Views.ToolBar));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}