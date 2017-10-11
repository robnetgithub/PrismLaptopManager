using LaptopRepository.Interface;
using Laptops.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LaptopRepository.Service
{
    public class ServiceRepository : ILaptopRepository
    {
        LaptopService ServiceProxy = new LaptopService();

        public ObservableCollection<Laptop> GetAllLaptops()
        {
            return ServiceProxy.GetAllLaptops();
        }

        public ObservableCollection<Laptop> GetPoolLaptops()
        {
            return ServiceProxy.GetPoolLaptops();
        }

        public Laptop GetLaptop(string hostname)
        {
            return ServiceProxy.GetLaptop(hostname);
        }

        public void AddLaptop(Laptop newLaptop)
        {
            ServiceProxy.AddLaptop(newLaptop);
        }

        public void UpdateLaptop(string hostname, Laptop updatedLaptop)
        {
             ServiceProxy.UpdateLaptop(hostname, updatedLaptop);
        }

        public void DeleteLaptop(string hostname)
        {
             ServiceProxy.DeleteLaptop(hostname);
        }

        public void UpdateLaptops(ObservableCollection<Laptop> updatedLaptops)
        {
            ServiceProxy.UpdateLaptops(updatedLaptops);
        }


        public ObservableCollection<User> GetUsers()
        {
            return ServiceProxy.GetUsers();
        }

        public User GetUserByID(string soeID)
        {
            return ServiceProxy.GetUserByID(soeID);
        }

        public ObservableCollection<Transaction> GetTransactions()
        {
            return ServiceProxy.GetTransactions();
        }

        public Transaction GetTransactonByID(int id)
        {
            return ServiceProxy.GetTransactonByID(id);
        }

        public void AddTransaction(Transaction newTransaction)
        {
            ServiceProxy.AddTransaction(newTransaction);
        }

        public void DeleteTransaction(int id)
        {
            ServiceProxy.DeleteTransaction(id);
        }

        public void UpdateTransaction(int id, Transaction updatedTransaction)
        {
            ServiceProxy.UpdateTransaction(id, updatedTransaction);
        }

        public void UpdateTransactions(ObservableCollection<Transaction> updatedTransactions)
        {
            ServiceProxy.UpdateTransactions(updatedTransactions);
        }
    }
}
