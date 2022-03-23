using API.JsonModels;
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

        private readonly HangmanGame _hangmanGame;

        public HangmanController(IMapper mapper, IAccountRepository accountRepository, IPrincipal principal, HangmanGame hangmanGame)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _principal = principal;
            _hangmanGame = hangmanGame;
        }

        [HttpGet]
        [Route("Start")]
        public ActionResult<bool> StartGame()
        {
            //_hangmanGame.start();
            return true;
        }

        [HttpGet]
        [Route("Stop")]
        public ActionResult<bool> StopGame()
        {
            //_hangmanGame.stop();
            return true;
        }

        [HttpGet]
        [Route("GuessLetter")]
        public ActionResult<HangmanResponseModel> GuessLetter(string letter)
        {
            //_hangmanGame.guessLetter(letter);
            return Ok(new HangmanResponseModel());
        }

        [HttpGet]
        [Route("GuessWord")]
        public ActionResult<HangmanResponseModel> GuessWord(string word)
        {
            //_hangmanGame.guessWord(word);
            return Ok(new HangmanResponseModel());
        }
    }
}
