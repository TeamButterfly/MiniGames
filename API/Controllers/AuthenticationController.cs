using API.JsonModels;
using AutoMapper;
using BuisnessLogic;
using BuisnessLogic.Exceptions;
using BuisnessLogic.Repository;
using BuisnessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;

        public AuthenticationController(IConfiguration config, IMapper mapper, ITokenService tokenService, IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _config = config;
            _mapper = mapper;
            _tokenService = tokenService;
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
        public ActionResult<LoginModel> Login(UserModelUpdate userModel)
        {
            var validUser = _userRepository.Login(_mapper.Map<User>(userModel));

            if (validUser != null)
            {
                var generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), _config["Jwt:Audience"].ToString(), validUser);
                if (generatedToken != null)
                {
                    var account = _accountRepository.GetAccountByUserId(validUser.UserId);
                    HttpContext.Session.SetString("Token", generatedToken);
                    return Ok(new LoginModel { Token = generatedToken, Account = _mapper.Map<AccountModel>(account)});
                }
                else
                {
                    throw new Exception("Token kunne ikke bygges");
                }
            }
            else
            {
                throw new HttpBadRequestException("Forkert brugernavn eller password");
            }
        }

        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public ActionResult<bool> Register(UserModelUpdate userModel)
        {
            _userRepository.CreateUser(_mapper.Map<User>(userModel));
            return Ok(true);
        }
    }
}
