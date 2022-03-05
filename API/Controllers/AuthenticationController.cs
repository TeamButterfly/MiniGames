using API.JsonModels;
using AutoMapper;
using BuisnessLogic;
using BuisnessLogic.Repository;
using BuisnessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;

        public AuthenticationController(IConfiguration config, IMapper mapper, ITokenService tokenService, IUserRepository userRepository)
        {
            _config = config;
            _mapper = mapper;
            _tokenService = tokenService;
            _userRepository = userRepository;
        }


        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
        public ActionResult<bool> Login(UserModelUpdate userModel)
        {
            var validUser = _userRepository.Login(_mapper.Map<User>(userModel));

            if (validUser != null)
            {
                var generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), _config["Jwt:Audience"].ToString(), validUser);
                if (generatedToken != null)
                {
                    HttpContext.Session.SetString("Token", generatedToken);
                    return Ok(true);
                }
                else
                {
                    throw new Exception("Token kunne ikke bygges");
                }
            }
            else
            {
                return Unauthorized("Forkert brugernavn eller password");
            }
        }

        [Authorize]
        [Route("Verify")]
        [HttpGet]
        public ActionResult<bool> Verify()
        {
            return Ok(true);
        }
    }
}
