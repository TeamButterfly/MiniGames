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
    [Authorize]
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
        [HttpPost]
        public ActionResult<SlidePuzzleModel> StartGame()
        {
            var game = new SPGame();
            game.setup();
            return Ok(new SlidePuzzleModel());
        }
        [Route("Start")]
        [HttpGet]
        public ActionResult<SlidePuzzleModel> GetStartBoard()
        {
            var game = new SPGame();
            game.createboard();
            return Ok(new SlidePuzzleModel());
        }

        [Route("Play")]
        [HttpPost]
        public ActionResult<SlidePuzzleModel> PlaySPGame()
        {
            var game = new SPGame();
            game.play();
            return Ok(new SlidePuzzleModel());
        }
        [Route("Play")]
        [HttpGet]
        public ActionResult<SlidePuzzleModel> Move()
        {
            var game = new SPGame();
            game.move();
            return Ok(new SlidePuzzleModel());
        }
        [Route("DisplayBoard")]
        [HttpGet]
        public ActionResult<SlidePuzzleModel> GetBoard()
        {
            var game = new SPGame();
            game.display();
            return Ok(new SlidePuzzleModel());
        }
        [Route("Solution")]
        [HttpPost]
        public ActionResult<SlidePuzzleModel> Solved()
        {
            var game = new SPGame();
            game.isComplited();
            return Ok(new SlidePuzzleModel());
        }
        [Route("Solution")]
        [HttpGet]
        public ActionResult<SlidePuzzleModel> Solution()
        {
            var game = new SPGame();
            game.solution();
            return Ok(new SlidePuzzleModel());
        }
        [Route("Swap")]
        [HttpGet]
        public ActionResult<SlidePuzzleModel> Neigbors(int valueToSwap)
        {
            var game = new SPGame();
            game.isNeighbor(valueToSwap);
            return Ok(new SlidePuzzleModel());
        }
        [Route("Swap")]
        [HttpPost]
        public ActionResult<SlidePuzzleModel> Swapping(int valueToSwap)
        {
            var game = new SPGame();
            game.swap(valueToSwap);
            return Ok(new SlidePuzzleModel());
        }

        [Route("/points")]
        [HttpPost]
        public ActionResult<SlidePuzzleModel> GivePoints()
        {
            var account = _accountRepository.GetAccountByUserId(Guid.Parse(_principal.Identity.Name));
            var game = new SPGame();
            account.Points = game.getPoints();
            _accountRepository.UpdateAccount(account);
            return Ok(new SlidePuzzleModel());
        }
    }
}
