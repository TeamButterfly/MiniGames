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
    [Authorize]
    public class AdminAccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AdminAccountController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        //DER SKAL VÆRE EN ADMIN ROLLE FØR DISSE BURDE TILLADES :)

        //[Route("GetAllAccounts")]
        //[HttpGet]
        //public ActionResult<List<AccountModel>> GetAccounts()
        //{
        //    var accounts = _accountRepository.GetAccounts();
        //    return Ok(_mapper.Map<List<AccountModel>>(accounts));
        //}

        //[Route("GetAccountByUserId")]
        //[HttpGet]
        //public ActionResult<AccountModel> GetAccountByUserId(Guid id)
        //{
        //    var account = _accountRepository.GetAccountByUserId(id);
        //    return Ok(_mapper.Map<AccountModel>(account));
        //}

        //[HttpGet]
        //public ActionResult<AccountModel> GetAccount(Guid id)
        //{
        //    var account = _accountRepository.GetAccount(id);
        //    return Ok(_mapper.Map<AccountModel>(account));
        //}

        //[HttpPut]
        //public ActionResult<bool> UpdateAccount(AccountModel account)
        //{
        //    var result = _accountRepository.UpdateAccount(_mapper.Map<Account>(account));
        //    return Ok(result);
        //}
    }

}