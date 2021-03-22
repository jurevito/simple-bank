using AutoMapper;
using BankAPI.Data;
using BankAPI.Dto;
using BankAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly SqlRepo _repository;
        private readonly IMapper _mapper;

        public AccountsController(SqlRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name="GetAccountById")]
        public ActionResult<AccountReadDTO> GetAccountById(int id)
        {
            var account = _repository.GetAccountById(id);

            if (account != null) return Ok(_mapper.Map<AccountReadDTO>(account));
            return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<AccountReadDTO>> GetAccounts()
        {
            var accounts = _repository.GetAccounts();
            return Ok(_mapper.Map<IEnumerable<AccountReadDTO>>(accounts));
        }

        [HttpPost]
        public ActionResult<AccountCreateDTO> CreateAccount(AccountCreateDTO accountDTO)
        {
            var accountModel = _mapper.Map<Account>(accountDTO);
            _repository.CreateAccount(accountModel);
            _repository.SaveChanges();

            var accountReadDTO = _mapper.Map<AccountReadDTO>(accountModel);

            return CreatedAtRoute(
                nameof(GetAccountById), 
                new { accountReadDTO.Id }, 
                accountReadDTO
            );
        }
    }
}
