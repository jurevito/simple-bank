using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models
{
    public class Transfer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Account")]
        public int SenderID { get; set; }

        [ForeignKey("Account")]
        public int ReceiverID { get; set; }

        [Required]
        public double Amount { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TimeStamp { get; set; }
    }
}
