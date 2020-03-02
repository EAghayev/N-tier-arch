using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models;
using Core.Services.Data;
using Manage.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper,
                              IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserById(id);

            var userResource = _mapper.Map<User, UserResource>(user);

            return Ok(userResource);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Register([FromBody]UserCreateResource userCreateResource)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserCreateResource, User>(userCreateResource);

                var userNotExists = await _userService.CheckEmail(user.Email);

                if (!userNotExists)
                    return Conflict();

                await _userService.CreateUser(user);

                var userResource = _mapper.Map<User, UserResource>(user);

                return Ok(userResource);
            }

            return BadRequest("Salam Elchin");
        }

    }
}