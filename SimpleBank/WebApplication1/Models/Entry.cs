using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public int AccountID { get; set; }
        public double Amount { get; set; }
        public string TimeStamp { get; set; }
    }
}
