using BankAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Data
{
    public class SqlRepo : IAccount
    {
        private readonly BankContext _context;

        public SqlRepo(BankContext context) 
        {
            _context = context;
        }

        public Account GetAccountById(int id)
        {
            return _context.Accounts.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _context.Accounts.ToList();
        }
    }
}
