using BankAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Data
{
    public interface ITransfer
    {
        Transfer GetTransferById(int id);
        IEnumerable<Transfer> GetTransfers();
        void MakeTransfer(Transfer transfer, Account sender, Account reciever);
    }
}
