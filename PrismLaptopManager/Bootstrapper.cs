using LaptopRepository.Interface;
using LaptopRepository.Service;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using PrismLaptopManager.Infrastructure;
using System.Windows;
using System.Windows.Controls;

namespace PrismLaptopManager
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IShellViewModel, ShellViewModel>();
            Container.RegisterType<ILaptopRepository, ServiceRepository>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            ModuleCatalog catalog = new ModuleCatalog();
            catalog.AddModule(typeof(Toolbar.ToolbarModule));
            catalog.AddModule(typeof(PoolLaptops.PoolLaptopsModule));
            catalog.AddModule(typeof(AllLaptops.AllLaptopsModule));
            catalog.AddModule(typeof(Statusbar.StatusbarModule));
            catalog.AddModule(typeof(TransactionHistory.TransactionHistoryModule));
            return catalog;
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            return mappings;
        }
    }
}
