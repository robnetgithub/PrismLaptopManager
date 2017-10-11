using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Laptops.Service
{
    public class LaptopService : ILaptopService
    {
        #region Laptop functions

        public ObservableCollection<Laptop> GetAllLaptops() 
        {
            using (var context = new ArdvarcEntities())
            {
                var laptops = new ObservableCollection<Laptop>(context.Laptops);
                return laptops;
            }
        }

        public ObservableCollection<Laptop> GetPoolLaptops()
        {
            using (var context = new ArdvarcEntities())
            {
                var matchingLaptops = context.Laptops.Where(l => l.Pool_Laptop == true).ToList();
                ObservableCollection<Laptop> poolLaptops = new ObservableCollection<Laptop>();
                foreach (var laptop in matchingLaptops)
                {
                    poolLaptops.Add(laptop);
                }
                return poolLaptops;
            }
        }

        public Laptop GetLaptop(string hostname) 
        {
            using (var context = new ArdvarcEntities())
            {
                var laptop = context.Laptops.Find(hostname);
                return laptop;
            }
        }

        public void AddLaptop(Laptop newLaptop) 
        {
            using (var context = new ArdvarcEntities())
            {
                context.Laptops.Add(newLaptop);
                context.SaveChanges();
            }
        }

        public void UpdateLaptop(string hostname, Laptop updatedLaptop) 
        {
            using (var context = new ArdvarcEntities())
            {
                var laptop = context.Laptops.FirstOrDefault(l => l.Hostname == hostname);

                laptop.Pool_Laptop = updatedLaptop.Pool_Laptop;
                laptop.PL_Booked_From = updatedLaptop.PL_Booked_From;
                laptop.PL_Booked_To = updatedLaptop.PL_Booked_To;
                laptop.PL_User_SOEID = updatedLaptop.PL_User_SOEID;
                laptop.PL_Booking_CMP = updatedLaptop.PL_Booking_CMP;
                laptop.PL_Checked_IN = updatedLaptop.PL_Checked_IN;
                laptop.PL_Updated_By = updatedLaptop.PL_Updated_By;
                laptop.Retired = updatedLaptop.Retired;
                laptop.Retired_Date = updatedLaptop.Retired_Date;
                laptop.Notes = updatedLaptop.Notes;

                context.SaveChanges();
            }
        }

        public void DeleteLaptop(string hostname) 
        {
            using (var context = new ArdvarcEntities())
            {
                var matchingLaptops = context.Laptops.Where(l => l.Hostname == hostname).ToList();
                foreach (var laptop in matchingLaptops) { 
                    context.Laptops.Remove(laptop);
                }
                context.SaveChanges();
            }
        }

        public void UpdateLaptops(ObservableCollection<Laptop> updatedLaptops) { }

        #endregion

        #region User functions

        public ObservableCollection<User> GetUsers()
        {
            using (var context = new ArdvarcEntities())
            {
                var users = new ObservableCollection<User>(context.Users);
                return users;
            }
        }

        public User GetUserByID(string soeID)
        {
            using (var context = new ArdvarcEntities())
            {
                var user = context.Users.Find(soeID);
                return user;
            }
        }

        #endregion

        #region Transaction functions

        public ObservableCollection<Transaction> GetTransactions()
        {
            using (var context = new ArdvarcEntities())
            {
                var transactions = new ObservableCollection<Transaction>(context.Transactions);
                return transactions;
            }
        }

        public Transaction GetTransactonByID(int id)
        {
            using (var context = new ArdvarcEntities())
            {
                var transaction = context.Transactions.Find(id);
                return transaction;
            }
        }

        public void AddTransaction(Transaction newTransaction)
        {
            using (var context = new ArdvarcEntities())
            {
                context.Transactions.Add(newTransaction);
                context.SaveChanges();
                context.Dispose();
            }
        }

        public void DeleteTransaction(int id)
        {
            using (var context = new ArdvarcEntities())
            {
                var matchingTransactions = context.Transactions.Where(l => l.ID == id).ToList();
                foreach (var transaction in matchingTransactions)
                {
                    context.Transactions.Remove(transaction);
                }
                context.SaveChanges();
            }
        }

        public void UpdateTransaction(int id, Transaction updatedTransaction)
        {
            using (var context = new ArdvarcEntities())
            {
                var transaction = context.Transactions.FirstOrDefault(l => l.ID == id);

                transaction.ID = updatedTransaction.ID;
                transaction.Serial = updatedTransaction.Serial;
                transaction.Hostname = updatedTransaction.Hostname;
                transaction.CheckedOutTo = updatedTransaction.CheckedOutTo;
                transaction.Status = updatedTransaction.Status;
                transaction.Date_Time = updatedTransaction.Date_Time;
                transaction.Updated_By = updatedTransaction.Updated_By;
                
                context.SaveChanges();
            }
        }

        public void UpdateTransactions(ObservableCollection<Transaction> updatedTransactions)
        {

        }

        #endregion
    }
}
