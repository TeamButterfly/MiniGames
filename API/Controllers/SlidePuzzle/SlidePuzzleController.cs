﻿using API.JsonModels;
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

        public SlidePuzzleController(IMapper mapper, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [Route("Start")]
        [HttpPost]
        public ActionResult<SlidePuzzleModel> StartGame()
        {
            var game = new Game();
            game.setup();
            return Ok(new SlidePuzzleModel());
        }

        //[Route("/points")]
        //[HttpPost]
        //public ActionResult<SlidePuzzleModel> GivePoints()
        //{
        //    var account = _accountRepository.GetAccountByUserId(Guid.Parse(_principal.Identity.Name));
        //    var game = new Game();
        //    account.Points += game.getPoints();
        //    _accountRepository.UpdateAccount(account);
        //    return Ok(new SlidePuzzleModel());
        //}

        //[HttpPost]
        //public ActionResult<SlidePuzzleModel> CountMoves()
        //{
        //    var game = new Game();
        //    game.getAmountOfMoves();
        //    return Ok(new SlidePuzzleModel());
        //}

        [HttpGet]
        public ActionResult<SlidePuzzleModel> Move()
        {
            var game = new Game();
            game.move();
            return Ok(new SlidePuzzleModel());
        }
    }
}