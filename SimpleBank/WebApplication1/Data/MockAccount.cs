using BankAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Data
{
    public class MockAccount : IAccount
    {
        public Account GetAccountById(int id)
        {
            return new Account { Id = 0, Name = "Johnny Bravo", Balance = 200f };
        }

        public IEnumerable<Account> GetAccounts()
        {
            var accounts = new List<Account>
            {
                new Account { Id = 0, Name = "Johnny Bravo", Balance = 200.00 },
                new Account { Id = 1, Name = "Scrooge McDuck", Balance = 10000.00 },
                new Account { Id = 0, Name = "Fiddleford McGucket", Balance = 0.56 },
            };

            return accounts;
        }
    }
}
