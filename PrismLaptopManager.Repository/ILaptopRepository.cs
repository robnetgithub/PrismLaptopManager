using System.Collections.Generic;
using Laptops.Service;
using System.Collections.ObjectModel;


namespace LaptopRepository.Interface
{
    public interface ILaptopRepository
    {
        #region Laptop functions

        ObservableCollection<Laptop> GetAllLaptops();
        ObservableCollection<Laptop> GetPoolLaptops();

        Laptop GetLaptop(string hostname);

        void AddLaptop(Laptop newLaptop);

        void UpdateLaptop(string hostname, Laptop updatedLaptop);

        void DeleteLaptop(string hostname);

        void UpdateLaptops(ObservableCollection<Laptop> updatedLaptops);

        #endregion

        #region User functions

        ObservableCollection<User> GetUsers();

        User GetUserByID(string soeID);

        #endregion


        #region Audit functions

        ObservableCollection<Transaction> GetTransactions();

        Transaction GetTransactonByID(int id);

        void AddTransaction(Transaction newTransaction);

        void DeleteTransaction(int id);

        void UpdateTransaction(int id, Transaction updatedTransaction);

        void UpdateTransactions(ObservableCollection<Transaction> updatedTransactions);

        #endregion
    }
}
