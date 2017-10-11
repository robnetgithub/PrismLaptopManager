using AllLaptops.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using PrismLaptopManager.Infrastructure;

namespace AllLaptops
{
    public class AllLaptopsModule : IModule
    {
        IRegionManager regionManager;
        IUnityContainer container;

        public AllLaptopsModule(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }

        public void Initialize()
        {
            regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(AllLaptopsView));
            regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(EditLaptopView));
        }
    }
}
