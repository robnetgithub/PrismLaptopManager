using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using PrismLaptopManager.Infrastructure;
using TransactionHistory.ViewModels;
using TransactionHistory.Views;

namespace TransactionHistory
{
    public class TransactionHistoryModule : IModule
    {
        IRegionManager regionManager;
        IUnityContainer container;

        public TransactionHistoryModule(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }

        public void Initialize()
        {
            container.RegisterType<ITransactionHistoryView, TransactionHistoryView>();
            container.RegisterType<ITransactionHistoryViewModel, TransactionHistoryViewModel>();
            regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(TransactionHistoryView));
        }

    }
}
