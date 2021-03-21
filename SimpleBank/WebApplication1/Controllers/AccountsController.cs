﻿using BankAPI.Data;
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
        private readonly SqlRepo repo;

        public AccountsController(SqlRepo repository)
        {
            repo = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<Account> GetAccountById(int id) => Ok(repo.GetAccountById(id));

        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAccounts() => Ok(repo.GetAccounts());
    }
}
