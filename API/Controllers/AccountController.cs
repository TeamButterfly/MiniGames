using API.JsonModels;
using AutoMapper;
using BuisnessLogic.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Principal;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPrincipal _principal;
        private readonly IMapper _mapper;

        public AccountController(IMapper mapper, IAccountRepository accountRepository, IPrincipal principal)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _principal = principal;
        }

        [HttpGet]
        public ActionResult<AccountModel> GetAccount()
        {
            var userId = Guid.Parse(_principal.Identity.Name);

            var account = _accountRepository.GetAccountByUserId(userId);
            return Ok(_mapper.Map<AccountModel>(account));
        }
    }
}
