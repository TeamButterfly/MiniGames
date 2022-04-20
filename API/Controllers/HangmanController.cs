using API.JsonModels;
using AutoMapper;
using BuisnessLogic.Repository;
using Hangman;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

//TODO: Skal ikke sende ordet med retur
//TODO: Skal sende ordlængden
//TODO: Skal sende respons hvis bogstavet er rigtigt med hvor i ordet bogstavet er gættet
//TODO: Skal give point ved vundet spil

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
            _hangmanGame.start();
            return true;
        }

        [HttpGet]
        [Route("Stop")]
        public ActionResult<bool> StopGame()
        {
            _hangmanGame.Stop();
            return true;
        }

        [HttpGet]
        [Route("GuessLetter")]
        public ActionResult<HangmanResponseModel> GuessLetter(string letter)
        {
            //_hangmanGame.guessLetter(letter);
            HangmanResponseModel model = new HangmanResponseModel();
            _hangmanGame.PlayerGuess(letter);
            model.word = _hangmanGame.getword();
            model.Life = _hangmanGame.getlives();
            model.IsGameRunning = _hangmanGame.getIsGameRunning();
            model.IsLetterGuessed = _hangmanGame.getisGameWon();
            model.guessletter = letter;
            model.wrongguesses = _hangmanGame.getwrongguesses();
            model.playerguesses = _hangmanGame.getplayerguesses();
            model.wordlength = _hangmanGame.getword().Length;
           

            
            return Ok(model);
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
