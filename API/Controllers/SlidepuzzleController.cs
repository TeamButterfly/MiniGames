using Microsoft.AspNetCore.Mvc;
using API.JsonModels;
using AutoMapper;
using BuisnessLogic.Repository;
using Microsoft.AspNetCore.Authorization;
using Slide_Puzzle;
using System;
using System.Security.Principal;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    
    public class SlidePuzzleController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IPrincipal _principal;
        private readonly GameManager _gameManager;


        public SlidePuzzleController(IMapper mapper, IAccountRepository accountRepository, GameManager gameManager, IPrincipal principal)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _gameManager = gameManager;
            _principal = principal;
        }

        [Route("Reset")]
        [HttpGet]
        public ActionResult<SlidePuzzleResponseModel> Reset(int size)
        {
            var userId = Guid.Parse(_principal.Identity.Name);
            var slidePuzzleModel = new SlidePuzzleResponseModel
            {
                Board = _gameManager.SlidePuzzleResetGame(userId, size),
                IsGameWon = _gameManager.SlidePuzzleIsCompleted(userId)
            };
            return Ok(slidePuzzleModel);
        }

        [Route("Move")]
        [HttpGet]
        public ActionResult<SlidePuzzleResponseModel> Move(int swapvalue)
        {
            var userId = Guid.Parse(_principal.Identity.Name);
            var slidePuzzleModel = new SlidePuzzleResponseModel
            {
                Board = _gameManager.SlidePuzzleMove(userId, swapvalue),
                IsGameWon = _gameManager.SlidePuzzleIsCompleted(userId)
            };
            if (slidePuzzleModel.IsGameWon)
            {
                GivePoints();
            }
            return Ok(slidePuzzleModel);
        }

        private void GivePoints()
        {
            var userId = Guid.Parse(_principal.Identity.Name);
            var account = _accountRepository.GetAccountByUserId(userId);
            account.Points += (int)Math.Floor(_gameManager.SlidePuzzleGetScore(userId)/5.0);
            _accountRepository.UpdateAccount(account);
        }
    }
}
