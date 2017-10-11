using Laptops.Service;
using Prism.Commands;
using Prism.Regions;
using PrismLaptopManager.Infrastructure;
using System;
using System.Windows;

namespace PrismLaptopManager
{
    public class ShellViewModel : ViewModelBase, IShellViewModel
    {
        #region Fields

        private readonly IRegionManager regionManager;

        #endregion Fields

        #region Properties

        public DelegateCommand<object> NavigateCommand { get; private set; }
        
        #endregion Properties

        #region Constructors

        public ShellViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand<object>(Navigate);
            ApplicationCommands.NavigateCommand.RegisterCommand(NavigateCommand);
        }

        #endregion

        #region Methods

        //private void CheckinCheckoutLaptop(Laptop laptop)
        //{
        //    if (laptop != null)
        //    {
        //        MessageBox.Show(String.Format("Navigation to {0} initiated... ", laptop.Hostname));
        //    }
        //}

        private void Navigate(object navigatePath)
        {
            if (navigatePath != null)
                regionManager.RequestNavigate(RegionNames.ContentRegion, navigatePath.ToString(), NavigationComplete);
        }

        private void NavigationComplete(NavigationResult result)
        {
            //MessageBox.Show(String.Format("Navigation to {0} complete. ", result.Context.Uri));
        }

        #endregion

    }
}
