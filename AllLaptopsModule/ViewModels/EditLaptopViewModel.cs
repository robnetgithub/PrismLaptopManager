using LaptopRepository.Interface;
using Laptops.Service;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismLaptopManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace AllLaptops.ViewModels
{
    public class EditLaptopViewModel : BindableBase, INavigationAware
    {
        #region Fields

        private const string AllLaptopsViewKey = "AllLaptopsView";
        private Laptop laptopToEdit;
        private Laptop selectedLaptop;
        private DelegateCommand saveCommand;
        private DelegateCommand cancelCommand;
        private ILaptopRepository repository;
        IRegionManager regionManager;
        private List<string> laptopStatuses = new List<string>() { "Checked In", "Checked Out" };

        #endregion

        #region Properties

        public Laptop LaptopToEdit
        {
            get { return this.laptopToEdit; }

            set { this.SetProperty(ref this.laptopToEdit, value); }
        }

        public Laptop SelectedLaptop
        {
            get { return this.selectedLaptop; }

            set { this.SetProperty(ref this.selectedLaptop, value); }
        }

        public List<string> LaptopStatuses
        {
            get { return this.laptopStatuses; }

            set { this.SetProperty(ref this.laptopStatuses, value); }
        }

        #endregion

        #region Constructors

        public EditLaptopViewModel(IRegionManager regionManager, ILaptopRepository repository)
        {
            this.regionManager = regionManager;
            saveCommand = new DelegateCommand(UpdateLaptop);
            cancelCommand = new DelegateCommand(CancelEdit);
            this.repository = repository;
        }

        #endregion

        #region Commands

        public ICommand SaveCommand
        {
            get { return this.saveCommand; }
        }

        public ICommand CancelCommand
        {
            get { return this.cancelCommand; }
        }

        #endregion

        #region Methods

        private void UpdateLaptop()
        {
            repository.UpdateLaptop(this.LaptopToEdit.Hostname, LaptopToEdit);
            LaptopToEdit = null;
            var uri = new Uri(AllLaptopsViewKey, UriKind.Relative);
            this.regionManager.RequestNavigate(RegionNames.ContentRegion, uri);
        }

        private void CancelEdit()
        {
            LaptopToEdit = null;
            NavigationParameters parameters = new NavigationParameters();
            var uri = new Uri(AllLaptopsViewKey, UriKind.Relative);
            this.regionManager.RequestNavigate(RegionNames.ContentRegion, uri);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var hostnameToEdit = navigationContext.Parameters["Hostname"];
            RetrieveLaptop(hostnameToEdit.ToString());
        }

        private void RetrieveLaptop(string hostnameToEdit)
        {
            if (hostnameToEdit != null)
            {
                LaptopToEdit = repository.GetLaptop(hostnameToEdit);
            }
        }

        #endregion

    }
}
