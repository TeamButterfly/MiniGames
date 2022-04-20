using API.JsonModels;
using AutoMapper;
using BuisnessLogic.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly TicTacToeGame _tictactoeGame;

        public TicTacToeController(IMapper mapper, IAccountRepository accountRepository, IPrincipal principal, TicTacToeGame tictactoeGame)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _principal = principal;
            _tictactoeGame = tictactoeGame;
        }

    }
}
