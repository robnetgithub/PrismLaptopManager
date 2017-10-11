using LaptopRepository.Interface;
using Laptops.Service;
using PoolLaptops.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using PrismLaptopManager.Infrastructure;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace PoolLaptops.ViewModels
{
    class PoolLaptopsViewModel : BindableBase, IPoolLaptopsViewModel, INavigationAware
    {
        #region Fields

        private const string LaptopHostnameKey = "Hostname";
        private const string EditLaptopViewKey = "LaptopCheckinCheckoutView";
        private ILaptopRepository repository;
        private readonly IRegionManager regionManager;
        private Laptop selectedLaptop;
        private DelegateCommand<Laptop> editLaptopCommand;
        IEventAggregator eventAggregator;
        private ObservableCollection<Laptop> laptops; 
                                            
        #endregion

        #region Properties

        public Laptop SelectedLaptop
        {
            get { return selectedLaptop; }
            set { SetProperty(ref selectedLaptop, value); }
        }

        public ObservableCollection<Laptop> Laptops
        {
            get 
            {
                return laptops; 
            }
            set 
            { 
                SetProperty(ref laptops, value); 
            }
        }
        
        #endregion

        #region Commands

        public ICommand EditLaptopCommand
        {
            get 
            { 
                return this.editLaptopCommand; 
            }    
        }

        #endregion

        #region Constructors

        public PoolLaptopsViewModel(IRegionManager regionManager, ILaptopRepository repository, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.repository = repository;
            this.Laptops = new ObservableCollection<Laptop>(repository.GetPoolLaptops());
            this.editLaptopCommand = new DelegateCommand<Laptop>(EditLaptop, CanEditLaptop);
            this.eventAggregator = eventAggregator;
        }

        private bool CanEditLaptop(Laptop arg)
        {
            return true;
        }

        #endregion

        #region Methods

        private void EditLaptop(Laptop laptopToEdit)
        {
            if (laptopToEdit != null)
            {
                NavigationParameters parameters = new NavigationParameters();
                parameters.Add(LaptopHostnameKey, laptopToEdit.Hostname);
                var uri = new Uri(typeof(LaptopCheckinCheckoutView).FullName + parameters, UriKind.Relative);
                regionManager.RequestNavigate(RegionNames.ContentRegion, uri);
            }
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
            Laptops = null;
            Laptops = new ObservableCollection<Laptop>(repository.GetPoolLaptops());
        }

        public bool KeepAlive
        {
            get { return true; }
        }

        #endregion 
    }
}
