using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Dto
{
    public class AccountCreateDTO
    {
        public string Name { get; set; }
        public double Balance { get; set; }
    }
}
