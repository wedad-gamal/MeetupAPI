﻿using MeetupAPI.Entities;
using MeetupAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MeetupContext _meetupContext;

        public AccountController(MeetupContext meetupContext)
        {
            _meetupContext = meetupContext;
        }
        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterUserDto registerUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newUser = new User() { 
                 Email = registerUserDto.Email,
                 Nationality = registerUserDto.Nationality,
                 DateOfBirth = registerUserDto.DateOfBirth,
                 RoleId = registerUserDto.RoleId
            };
            _meetupContext.Users.Add(newUser);
            _meetupContext.SaveChanges();

            return Ok(new { 
                message="Success",
                Id = newUser.Id

            });
        }
    }
}
