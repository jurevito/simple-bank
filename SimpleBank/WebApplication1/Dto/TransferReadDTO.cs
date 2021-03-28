using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Dto
{
    public class TransferReadDTO
    {
        public int Id { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public double Amount { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
