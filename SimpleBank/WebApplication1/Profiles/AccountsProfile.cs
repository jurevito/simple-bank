using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BankAPI.Dto;
using BankAPI.Models;

namespace BankAPI.Profiles
{
    public class AccountsProfile : Profile
    {
        public AccountsProfile()
        {
            CreateMap<Account, AccountReadDTO>();
            CreateMap<AccountCreateDTO, Account>();
            CreateMap<AccountUpdateDTO, Account>();
            CreateMap<Account, AccountUpdateDTO>();
        }
    }
}
