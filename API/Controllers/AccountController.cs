using API.JsonModels;
using AutoMapper;
using BuisnessLogic;
using BuisnessLogic.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/GetAllAccounts")]
        public ActionResult<List<JsonAccount>> GetAccounts()
        {
            var accounts = _accountRepository.GetAccounts();
            return Ok(_mapper.Map<List<JsonAccount>>(accounts));
        }

        [HttpGet]
        [Route("/GetAccountByUserId")]
        public ActionResult<JsonAccount> GetAccountByUserId(Guid id)
        {
            var account = _accountRepository.GetAccountByUserId(id);
            return Ok(_mapper.Map<JsonAccount>(account));
        }

        [HttpGet]
        public ActionResult<JsonAccount> GetAccount(Guid id)
        {
            var account = _accountRepository.GetAccount(id);
            return Ok(_mapper.Map<JsonAccount>(account));
        }

        [HttpPut]
        public ActionResult<bool> UpdateAccount(JsonAccount account)
        {
            var result = _accountRepository.UpdateAccount(_mapper.Map<Account>(account));
            return Ok(result);
        }
    }

}