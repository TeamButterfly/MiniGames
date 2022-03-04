using API.JsonModels;
using AutoMapper;
using BuisnessLogic;
using BuisnessLogic.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<bool> CreateUser(UserModelUpdate jsonUpdateUser)
        {
            var user = _mapper.Map<User>(jsonUpdateUser);
            var result = _userRepository.CreateUser(user);
            return Ok(result);
        }


        [Authorize]
        [HttpGet]
        [Route("/GetAllUsers")]
        public ActionResult<List<UserModel>> GetUsers()
        {
            var users = _userRepository.GetUsers();
            return Ok(_mapper.Map<List<UserModel>>(users));
        }

        [Authorize]
        [HttpGet]
        public ActionResult<UserModel> GetUser(Guid id)
        {
            var user = _userRepository.GetUser(id);
            return Ok(_mapper.Map<UserModel>(user));
        }

        [Authorize]
        [HttpPut]
        public ActionResult<bool> UpdateUser(UserModelUpdate jsonUpdateUser)
        {
            var user = _mapper.Map<User>(jsonUpdateUser);
            var result = _userRepository.UpdateUser(user);
            return Ok(result);
        }
    }

}