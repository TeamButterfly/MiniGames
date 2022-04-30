using API.JsonModels;
using AutoMapper;
using BuisnessLogic.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Principal;
using TicTacToe;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class TicTacToeController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPrincipal _principal;
        private readonly IMapper _mapper;
        private readonly GameManager _gameManager;

        public TicTacToeController(IMapper mapper, IAccountRepository accountRepository, IPrincipal principal, GameManager gameManager)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _principal = principal;
            _gameManager = gameManager;
        }

        [Route("Reset")]
        [HttpGet]
        public ActionResult<TicTacToeResponseModel> Reset(int squares)
        {
            var userId = Guid.Parse(_principal.Identity.Name);
            var ticTacToeModel = _gameManager.TicTacToeResetGame(userId, squares);
            return Ok(_mapper.Map<TicTacToeResponseModel>(ticTacToeModel));
        }

        [Route("SetField")]
        [HttpGet]
        public ActionResult<TicTacToeResponseModel> SetField(int row, int col)
        {
            var userId = Guid.Parse(_principal.Identity.Name);
            var ticTacToeModel = _gameManager.TicTacToeSetField(userId, row, col);
            if(ticTacToeModel.Winner == TicTacToeEnum.Cross)
            {
                GivePoints();
            }
            return Ok(_mapper.Map<TicTacToeResponseModel>(ticTacToeModel));
        }

        private void GivePoints()
        {
            var userId = Guid.Parse(_principal.Identity.Name);
            var account = _accountRepository.GetAccountByUserId(userId);
            account.Points += 100;
            _accountRepository.UpdateAccount(account);
        }
    }
}
