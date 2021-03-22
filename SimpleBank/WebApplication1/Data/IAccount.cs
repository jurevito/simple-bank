using BankAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Data
{
    public interface IAccount
    {
        bool SaveChanges();
        Account GetAccountById(int id);
        IEnumerable<Account> GetAccounts();
        void CreateAccount(Account account);
    }
}
