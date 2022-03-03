using API.JsonModels;
using AutoMapper;
using BuisnessLogic;
using BuisnessLogic.Repository;
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

        [HttpGet]
        [Route("/GetAllUsers")]
        public ActionResult<List<JsonUser>> GetUsers()
        {
            var users = _userRepository.GetUsers();
            return Ok(_mapper.Map<List<JsonUser>>(users));
        }

        [HttpGet]
        public ActionResult<List<JsonUser>> GetUser(Guid id)
        {
            var user = _userRepository.GetUser(id);
            return Ok(_mapper.Map<JsonUser>(user));
        }

        [HttpPost]
        public ActionResult<bool> CreateUser(JsonUpdateUser jsonUpdateUser)
        {
            var user = _mapper.Map<User>(jsonUpdateUser);
            var result = _userRepository.CreateUser(user);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult<bool> UpdateUser(JsonUpdateUser jsonUpdateUser)
        {
            var user = _mapper.Map<User>(jsonUpdateUser);
            var result = _userRepository.UpdateUser(user);
            return Ok(result);
        }
    }

}