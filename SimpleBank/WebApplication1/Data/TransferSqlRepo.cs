using BankAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Data
{
    public class TransferSqlRepo : ITransfer
    {
        private readonly BankContext _context;

        public TransferSqlRepo(BankContext context)
        {
            _context = context;
        }

        public Transfer GetTransferById(int id)
        {
            return _context.Transfers.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Transfer> GetTransfers()
        {
            return _context.Transfers.ToList();
        }

        public void MakeTransfer(Transfer transfer, Account sender, Account reciever)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (transfer == null) throw new ArgumentNullException(nameof(transfer));
                    if (sender == null) throw new ArgumentNullException(nameof(sender));
                    if (reciever == null) throw new ArgumentNullException(nameof(reciever));

                    _context.Transfers.Add(transfer);
                    _context.SaveChanges();

                    _context.Accounts.Update(sender);
                    _context.Accounts.Update(reciever);
                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
