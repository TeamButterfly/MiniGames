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
    
    public class SlidePuzzleController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IPrincipal _principal;
        private readonly SPGame _slidePuzzle;


        public SlidePuzzleController(IMapper mapper, IAccountRepository accountRepository, SPGame slide_Puzzle, IPrincipal principal)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _slidePuzzle = slide_Puzzle;
            _principal = principal;
        }

        [Route("Start")]
        [HttpGet]
        public ActionResult<SlidePuzzleModel> CreateBoard(int gamesize)
        {
            var board = _slidePuzzle.createboard(gamesize);
            var slidePuzzleModel = new SlidePuzzleModel
            {
                Board = board
            };
            return Ok(slidePuzzleModel);
        }

        [Route("Move")]
        [HttpGet]
        public ActionResult<SlidePuzzleModel> MoveTile(int swapvalue)
        {
            var boardUpdate = _slidePuzzle.move(swapvalue);
            var slidePuzzleModel = new SlidePuzzleModel
            {
                Board = boardUpdate
            };
            return Ok(slidePuzzleModel);
        }
       
        [Route("isComplited")]
        [HttpGet]
        public ActionResult<bool> Solved()
        {
            return Ok(_slidePuzzle.isComplited());
        }

        [Route("/points")]
        [HttpPost]
        public ActionResult<int> GivePoints()
        {
            var account = _accountRepository.GetAccountByUserId(Guid.Parse(_principal.Identity.Name));
            account.Points = 2/_slidePuzzle.getPoints();
            _accountRepository.UpdateAccount(account);
            return Ok(account.Points);
        }
    }
}
