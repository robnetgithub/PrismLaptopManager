using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using PrismLaptopManager.Infrastructure;
using Toolbar.Views;

namespace Toolbar
{
    public class ToolbarModule : IModule
    {
        IRegionManager regionManager;
        IUnityContainer container;

        public ToolbarModule(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }

        public void Initialize()
        {
            regionManager.RegisterViewWithRegion(RegionNames.ToolbarLeftRegion, typeof(ToolbarNavView));
            regionManager.RegisterViewWithRegion(RegionNames.ToolbarCentreRegion, typeof(SearchBoxView));
            regionManager.RegisterViewWithRegion(RegionNames.ToolbarRightRegion, typeof(ToolbarLoggededOnUserView));
        }
    }
}
