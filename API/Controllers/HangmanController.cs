using API.JsonModels;
using AutoMapper;
using BuisnessLogic.Repository;
using Hangman;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
         
        private readonly GameManager _gameManager;

        public HangmanController(IMapper mapper, IAccountRepository accountRepository, IPrincipal principal, GameManager gameManager)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _principal = principal;
            _gameManager = gameManager;
        }

        [HttpGet]
        [Route("Reset")]
        public ActionResult<HangmanResponseModel> ResetGame()
        {
            var userId = Guid.Parse(_principal.Identity.Name);
            var hangmanModel = _gameManager.HangmanResetGame(userId);
            return Ok(_mapper.Map<HangmanResponseModel>(hangmanModel));
        }

        [HttpGet]
        [Route("GuessLetter")]
        public ActionResult<HangmanResponseModel> GuessLetter(char letter)
        {
            var userId = Guid.Parse(_principal.Identity.Name);
            var hangmanModel = _gameManager.HangmanGuessLetter(userId, letter);
            return Ok(_mapper.Map<HangmanResponseModel>(hangmanModel));
        }

        [HttpGet]
        [Route("GuessWord")]
        public ActionResult<HangmanResponseModel> GuessWord(string word)
        {
            var userId = Guid.Parse(_principal.Identity.Name);
            var hangmanModel = _gameManager.HangmanGuessWord(userId, word);
            return Ok(_mapper.Map<HangmanResponseModel>(hangmanModel));
        }

      
    }
}
