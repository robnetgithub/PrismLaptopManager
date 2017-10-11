using PoolLaptops.Views;
using Prism.Modularity;
using Prism.Regions;
using PrismLaptopManager.Infrastructure;
using Microsoft.Practices.Unity;
using PoolLaptops.ViewModels;


namespace PoolLaptops
{
    public class PoolLaptopsModule : IModule
    {
        IRegionManager regionManager;
        IUnityContainer container;

        public PoolLaptopsModule(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }

        public void Initialize()
        {
            container.RegisterType<IPoolLaptopsView, PoolLaptopsView>();
            container.RegisterType<IPoolLaptopsViewModel, PoolLaptopsViewModel>();
            container.RegisterType<ILaptopCheckinCheckoutView, LaptopCheckinCheckoutView>();
            container.RegisterType<ILaptopCheckinCheckoutViewModel, LaptopCheckinCheckoutViewModel>();
            
            regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(PoolLaptopsView));
            regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(LaptopCheckinCheckoutView));
        }

        
    }
}
