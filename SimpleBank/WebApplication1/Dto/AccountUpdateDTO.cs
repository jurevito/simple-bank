using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Dto
{
    public class AccountUpdateDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Balance { get; set; }
    }
}
