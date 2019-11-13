using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SandrasBank.Web.Models
{
    public class BankRepository
    {
        public List<Account> Accounts { get; set; }
        public List<Customer> Customers { get; set; }

        public BankRepository()
        {
            Accounts = new List<Account>
            {
                new Account(){ Balance = 100m, AcccountId = 1, CustomerId = 1 },
                new Account(){ Balance = 200m, AcccountId = 2, CustomerId = 2 },
                new Account(){ Balance = 300m, AcccountId = 3, CustomerId = 3 },
                new Account(){ Balance = 400m, AcccountId = 4, CustomerId = 4 },
                new Account(){ Balance = 500m, AcccountId = 5, CustomerId = 5 }

            };

            Customers = new List<Customer>
            {
                new Customer(){ Name = "Sandra", AccountId = 1, CustomerId = 1 },
                new Customer(){ Name = "Alice", AccountId = 2, CustomerId = 2 },
                new Customer(){ Name = "Selma", AccountId = 3, CustomerId = 3 },
                new Customer(){ Name = "Richard", AccountId = 4, CustomerId = 4 },
                new Customer(){ Name = "Nova", AccountId = 5, CustomerId = 5 },

            };
        }

        public void Deposit(decimal amount, int accountId)
        {
            if (amount < 0) throw new Exception();
            var account = Accounts.SingleOrDefault(a => a.AcccountId == accountId);

            account.Balance += amount;
        }

        public void Withdraw(decimal amount, int accountId)
        {            
            var account = Accounts.SingleOrDefault(a => a.AcccountId == accountId);
            if (amount > account.Balance || amount < 0) throw new ArgumentOutOfRangeException();

                account.Balance -= amount;
        }

        public void Transfer(int accountIdFrom, int accountIdTo, decimal amount)
        {
            var accountFrom = Accounts.SingleOrDefault(x => x.AcccountId == accountIdFrom);
            var accountTo = Accounts.SingleOrDefault(x => x.AcccountId == accountIdTo);

            if (amount > accountFrom.Balance || amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                accountFrom.Balance -= amount;
                accountTo.Balance += amount;
            }
        }
    }
}
