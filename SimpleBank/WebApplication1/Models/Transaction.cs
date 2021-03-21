using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Account")]
        public int SenderID { get; set; }

        [ForeignKey("Account")]
        public int ReceiverID { get; set; }

        [Required]
        public double Amount { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
