using LaptopRepository.Interface;
using Laptops.Service;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismLaptopManager.Infrastructure;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;


namespace AllLaptops.ViewModels
{
    public class AllLaptopsViewModel : BindableBase, INavigationAware
    {
        #region Fields

        private const string LaptopHostnameKey = "Hostname";
        private const string EditLaptopViewKey = "EditLaptopView";

        private Laptop selectedLaptop;
        private ILaptopRepository repository;
        private readonly IRegionManager regionManager;
        private readonly DelegateCommand<Laptop> editLaptopCommand;
        private ObservableCollection<Laptop> laptops;
        //private ObservableCollection<Laptop> laptopsCollection;

        #endregion

        #region Properties

        public ObservableCollection<Laptop> Laptops 
        {
            get { return laptops; }
            set { SetProperty(ref laptops, value); }
        }

        public Laptop SelectedLaptop
        {
            get { return selectedLaptop; }
            set { SetProperty(ref selectedLaptop, value); }
        }

        #endregion

        #region Constructors

        public AllLaptopsViewModel(IRegionManager regionManager, ILaptopRepository repository)
        {
            this.regionManager = regionManager;
            this.repository = repository;
            Laptops = new ObservableCollection<Laptop>(repository.GetAllLaptops());
            //this.laptopsCollection = new ObservableCollection<Laptop>(repository.GetAllLaptops());
            //this.Laptops = new ListCollectionView(this.laptopsCollection);
            this.editLaptopCommand = new DelegateCommand<Laptop>(this.EditLaptop, this.CanEditLaptop);
        }

        #endregion

        #region Commands

        public ICommand EditLaptopCommand
        {
            get { return editLaptopCommand; }
        }

        #endregion

        #region Methods

        private bool CanEditLaptop(object ignored)
        {
            return true;
            //return this.Laptops.CurrentItem != null;
        }

        private void EditLaptop(Laptop selectedLaptop)
        {
            if (selectedLaptop != null)
            {
                NavigationParameters parameters = new NavigationParameters();
                parameters.Add(LaptopHostnameKey, selectedLaptop.Hostname);
                var uri = new Uri(EditLaptopViewKey + parameters, UriKind.Relative);
                this.regionManager.RequestNavigate(RegionNames.ContentRegion, uri);
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
            //this.laptopsCollection = null;
            this.Laptops = null;
            this.Laptops = new ObservableCollection<Laptop>(repository.GetAllLaptops());
            //this.Laptops = new ListCollectionView(this.laptopsCollection);
        }

        #endregion
    }
}
