using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleHistory.Logic.Services.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VehicleHistory.Logic.Models.Database;
using VehicleHistory.Logic.Models.Dtos;
using VehicleHistory.WebApi.Helpers;

namespace VehicleHistory.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService _usersService;

        private IMapper _mapper;

        private readonly AppSettings _appSettings;

        public UsersController(IUsersService usersService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _usersService = usersService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpGet("ping")
		public IActionResult Ping()
		{
			return Ok();
		}
    }
}
