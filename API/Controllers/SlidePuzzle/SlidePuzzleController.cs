using API.JsonModels;
using AutoMapper;
using BuisnessLogic.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Slide_Puzzle;
using System;
using System.Security.Principal;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]

    public class SlidePuzzleController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IPrincipal _principal;

        public SlidePuzzleController(IMapper mapper,IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<SlidePuzzleModel> GivePoints()
        {
            var account = _accountRepository.GetAccountByUserId(Guid.Parse(_principal.Identity.Name));
            account.Points += 2;
            _accountRepository.UpdateAccount(account);
            var game = new Game();
            return Ok(new SlidePuzzleModel());
        }
    }
}
