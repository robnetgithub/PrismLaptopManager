using LaptopRepository.Interface;
using Laptops.Service;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TransactionHistory.ViewModels
{
    public class TransactionHistoryViewModel : BindableBase, ITransactionHistoryViewModel, INavigationAware
    {

        #region Fields

        private ILaptopRepository repository;
        private readonly IRegionManager regionManager;
        private Transaction selectedTransaction;
        IEventAggregator eventAggregator;
        private ObservableCollection<Transaction> transactions; 
                                            
        #endregion

        #region Properties

        public Transaction SelectedTransaction
        {
            get { return selectedTransaction; }
            set { SetProperty(ref selectedTransaction, value); }
        }

        public ObservableCollection<Transaction> Transactions
        {
            get 
            {
                return transactions; 
            }
            set 
            { 
                SetProperty(ref transactions, value); 
            }
        }
        
        #endregion

        #region Commands

        #endregion

        #region Constructors

        public TransactionHistoryViewModel(IRegionManager regionManager, ILaptopRepository repository, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.repository = repository;
            this.Transactions = new ObservableCollection<Transaction>(repository.GetTransactions());
            this.eventAggregator = eventAggregator;
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
            Transactions = null;
            Transactions = new ObservableCollection<Transaction>(repository.GetTransactions());
        }

        public bool KeepAlive
        {
            get { return false; }
        }

        #endregion 
    }
}
