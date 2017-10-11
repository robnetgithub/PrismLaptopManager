using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using PrismLaptopManager.Infrastructure;
using Statusbar.Views;

namespace Statusbar
{
    public class StatusbarModule : IModule
    {
        IRegionManager regionManager;
        IUnityContainer container;

        public StatusbarModule(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }

        public void Initialize()
        {
            regionManager.RegisterViewWithRegion(RegionNames.StatusbarRegion, typeof(StatusbarView));

        }
    }
}