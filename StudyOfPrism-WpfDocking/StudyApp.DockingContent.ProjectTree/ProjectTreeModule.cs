using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace StudyApp.DockingContent.ProjectTree
{
    public class ProjectTreeModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(nameof(Views.ProjectTree), typeof(Views.ProjectTree));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}