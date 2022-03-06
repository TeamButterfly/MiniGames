using API.JsonModels;
using AutoMapper;
using BuisnessLogic;
using BuisnessLogic.Repository;
using BuisnessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Principal;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPrincipal _principal;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserRepository userRepository, IPrincipal principal)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _principal = principal;
        }

        [HttpPut]
        public ActionResult<bool> UpdateUser(UserModelUpdate jsonUpdateUser)
        {
            var user = _mapper.Map<User>(jsonUpdateUser);

            var userId = Guid.Parse(_principal.Identity.Name);
            user.UserId = userId;

            var result = _userRepository.UpdateUser(user);
            return Ok(result);
        }
    }
}
