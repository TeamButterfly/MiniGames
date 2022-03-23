using AutoMapper;
using BuisnessLogic.Repository;
using Hangman;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class HangmanController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPrincipal _principal;
        private readonly IMapper _mapper;

        public HangmanController(IMapper mapper, IAccountRepository accountRepository, IPrincipal principal)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _principal = principal;
        }

        [HttpGet]
        public ActionResult<bool> StartGame()
        {
            HangmanGame hangmanGame = new HangmanGame();
            return true;
        }


    }
}
