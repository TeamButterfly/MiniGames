using API.JsonModels;
using AutoMapper;
using BuisnessLogic;
using BuisnessLogic.Repository;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        [Route("/GetAllAccounts")]
        public ActionResult<List<AccountModel>> GetAccounts()
        {
            var accounts = _accountRepository.GetAccounts();
            return Ok(_mapper.Map<List<AccountModel>>(accounts));
        }

        [Authorize]
        [HttpGet]
        [Route("/GetAccountByUserId")]
        public ActionResult<AccountModel> GetAccountByUserId(Guid id)
        {
            var account = _accountRepository.GetAccountByUserId(id);
            return Ok(_mapper.Map<AccountModel>(account));
        }

        [Authorize]
        [HttpGet]
        public ActionResult<AccountModel> GetAccount(Guid id)
        {
            var account = _accountRepository.GetAccount(id);
            return Ok(_mapper.Map<AccountModel>(account));
        }

        [Authorize]
        [HttpPut]
        public ActionResult<bool> UpdateAccount(AccountModel account)
        {
            var result = _accountRepository.UpdateAccount(_mapper.Map<Account>(account));
            return Ok(result);
        }
    }

}