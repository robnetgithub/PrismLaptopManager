using LaptopRepository.Interface;
using Laptops.Service;
using PoolLaptops.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using PrismLaptopManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Windows;

namespace PoolLaptops.ViewModels
{
    public class LaptopCheckinCheckoutViewModel : BindableBase, ILaptopCheckinCheckoutViewModel, INavigationAware, IRegionMemberLifetime
    {
        #region Fields
        private const string LaptopHostnameKey = "Hostname";
        private const string EditLaptopViewKey = "EditLaptopView";
        private ILaptopRepository repository;
        private readonly IRegionManager regionManager;
        private Laptop laptopToEdit;
        public User selectedUser;
        private IEnumerable<User> users;
        private DelegateCommand<string> checkinCheckoutCommand;
        private DelegateCommand cancelCommand;
        IEventAggregator eventAggregator;

        #endregion

        #region Properties
        
        public Laptop LaptopToEdit
        {
            get { return laptopToEdit; }
            set { SetProperty(ref laptopToEdit, value); OnPropertyChanged(); }
        }

        public User SelectedUser
        {
            get { return selectedUser; }
            set { SetProperty(ref selectedUser, value); OnPropertyChanged(); }
        }

        public IEnumerable<User> Users
        {
            get { return users; }
            set { SetProperty(ref users, value); }
        }

        #endregion

        #region Commands

        public DelegateCommand<string> CheckinCheckoutCommand { get { return checkinCheckoutCommand; } }

        public DelegateCommand CancelCommand { get { return cancelCommand; } }

        #endregion

        #region Constructors

        public LaptopCheckinCheckoutViewModel(IRegionManager regionManager, ILaptopRepository repository, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.repository = repository;
            this.users = repository.GetUsers();
            this.checkinCheckoutCommand = new DelegateCommand<string>(CheckinCheckout);
            this.eventAggregator = eventAggregator;
            this.cancelCommand = new DelegateCommand(Cancel);
        }  

        #endregion

        #region Methods

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
            if (hostnameToEdit != null){
                LaptopToEdit = repository.GetLaptop(hostnameToEdit);
                SelectedUser = repository.GetUserByID(LaptopToEdit.PL_User_SOEID);
            }
        }

        public bool KeepAlive
        {
            get { return true; }
        }

        private void CheckinCheckout(string obj)
        {
            switch (obj)
            {
                case "CheckIn": Checkin(); break;
                case "CheckOut": Checkout(); break;
                case "CheckLaptop": CheckLaptop(); break;
                default: break;
            }
        }

        private void Checkout()
        {
            //Update the status of the selected laptop
            if (LaptopToEdit != null)
            {
                Laptop updatedLaptop = new Laptop();
                updatedLaptop = LaptopToEdit; // Clone all the unchanging fields (the new loan dates are included)
                updatedLaptop.PL_User_SOEID = SelectedUser.SOEID;
                updatedLaptop.PL_Checked_IN = LaptopStatus.CheckedOut; //The PL_Checked_IN field is how the Ardvarc DB stores laptop status
                updatedLaptop.PL_Updated_By = Environment.UserName;
                repository.UpdateLaptop(LaptopToEdit.Hostname, updatedLaptop);

                //create a new Transaction and add it to the Audit table
                Transaction newTransaction = new Transaction();
                newTransaction.Hostname = laptopToEdit.Hostname;
                newTransaction.Date_Time = DateTime.Now;
                newTransaction.Status = TransactionStatus.LoanedOut;
                newTransaction.CheckedOutTo = SelectedUser.SOEID;
                newTransaction.Serial = laptopToEdit.Serial;
                newTransaction.Updated_By = Environment.UserName;
                repository.AddTransaction(newTransaction);

                //Publish a message that the status bar is listening for
                eventAggregator.GetEvent<LaptopUpdatedEvent>().Publish(String.Format("Laptop {0} checked Out.", laptopToEdit.Hostname));

                //Navigate back to Pool Laptops View
                var uri = new Uri(typeof(PoolLaptopsView).FullName, UriKind.Relative);
                regionManager.RequestNavigate(RegionNames.ContentRegion, uri);
            }
        }

        private void Checkin()
        {
            //Update the status of the selected laptop
            if (LaptopToEdit != null)
            {
                Laptop updatedLaptop = new Laptop();
                updatedLaptop = laptopToEdit; // Clone all unchanging fields
                updatedLaptop.PL_User_SOEID = LaptopStatus.Empty;
                updatedLaptop.PL_Booked_From = null;
                updatedLaptop.PL_Booked_To = null;
                updatedLaptop.PL_Booking_CMP = LaptopStatus.Empty;
                updatedLaptop.PL_Checked_IN = LaptopStatus.CheckedIn;
                updatedLaptop.Notes = LaptopStatus.Empty;
                updatedLaptop.PL_Updated_By = Environment.UserName;

                repository.UpdateLaptop(laptopToEdit.Hostname, updatedLaptop);

                //Create a new Transaction and add it to the Audit table
                Transaction newTransaction = new Transaction();
                newTransaction.Hostname = laptopToEdit.Hostname;
                newTransaction.Date_Time = DateTime.Now;
                newTransaction.Status = TransactionStatus.CheckedIn;
                newTransaction.CheckedOutTo = TransactionStatus.Empty;
                newTransaction.Serial = laptopToEdit.Serial;
                newTransaction.Updated_By = Environment.UserName;
                repository.AddTransaction(newTransaction);

                //Publish a message that the status bar is listening for
                eventAggregator.GetEvent<LaptopUpdatedEvent>().Publish(String.Format("Laptop {0} checked in.", laptopToEdit.Hostname));

                //Navigate back to Pool Laptops View
                var uri = new Uri(typeof(PoolLaptopsView).FullName, UriKind.Relative);
                regionManager.RequestNavigate(RegionNames.ContentRegion, uri);
            }
        }

        private void CheckLaptop()
        {
            if (LaptopToEdit != null)
            {
                NavigationParameters parameters = new NavigationParameters();
                parameters.Add(LaptopHostnameKey, LaptopToEdit.Hostname);
                var uri = new Uri(EditLaptopViewKey + parameters, UriKind.Relative);
                this.regionManager.RequestNavigate(RegionNames.ContentRegion, uri);
            }
        }

        private void Cancel()
        {
            //Navigate back to Pool Laptops View
            var uri = new Uri(typeof(PoolLaptopsView).FullName, UriKind.Relative);
            regionManager.RequestNavigate(RegionNames.ContentRegion, uri);
        }

        #endregion
       
    }
}
