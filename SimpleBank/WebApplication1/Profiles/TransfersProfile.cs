using AutoMapper;
using BankAPI.Dto;
using BankAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Profiles
{
    public class TransfersProfile : Profile
    {
        public TransfersProfile()
        {
            CreateMap<Transfer, TransferReadDTO>();
            CreateMap<TransferCreateDTO, Transfer>();
        }
    }
}
