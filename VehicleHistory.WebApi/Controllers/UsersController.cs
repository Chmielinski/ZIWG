using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleHistory.Logic.Services.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VehicleHistory.Logic.Models.Database;
using VehicleHistory.Logic.Models.Dtos;
using VehicleHistory.Logic.Models.Utility;

namespace VehicleHistory.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UsersController(IDistributedCache cache, IUsersService usersService, IMapper mapper, IOptions<AppSettings> appSettings, ITokenService tokenService)
        {
            _usersService = usersService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _tokenService = tokenService;
        }
		
		[AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserDto userDto)
        {
            var user = _usersService.Authenticate(userDto.Email, userDto.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Email or password is incorrect" });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.Now.AddDays(_appSettings.TokenExpirationDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                user.Id,
                user.Email,
                user.FirstName,
                user.LastName,
                Token = tokenString,
                user.PasswordRecoveryActive,
                user.LocationId,
                user.Group
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto userDto)
        {
            var user = _mapper.Map(userDto, new User());

            try
            {
                _usersService.Create(user, userDto.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _usersService.GetAll();
            var userDtos = _mapper.Map<IList<UserDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            var user = _usersService.GetUserById(id);
            var userDto = _mapper.Map<User, UserDto>(user);
            return Ok(userDto);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public IActionResult UpdateUser(string id, [FromBody]UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<UserDto, User>(userDto);
                _usersService.UpdateUser(user, userDto.Password);
                userDto.Password = null;
                return Ok(userDto);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message, stackTrace = ex.StackTrace });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            try
            {
                _usersService.DeleteUser(id);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("reset-password")]
        public IActionResult SendPasswordResetEmail([FromBody] string email)
        {
            var user = _usersService.GetUserByEmail(email);
            if (user == null)
            {
                return Ok();
            }

            try
            {
                _usersService.SendPasswordRecoveryEmail(user, _appSettings);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            // Used for verifying the token mechanism
            return Ok();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _tokenService.DeactivateCurrentAsync();
            return Ok();
        }

        [HttpPost("validate-password")]
        public IActionResult ValidatePassword([FromBody] UserDto user)
        {
            try
            {
                if (_usersService.IsPasswordCorrect(!string.IsNullOrEmpty(user.OldPassword) ? user.OldPassword : user.Password, user.Email))
                {
                    return Ok(user);
                }
                return BadRequest(new {message = "Nieprawidłowe hasło"});

            }
            catch (AppException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpPost("check")]
        public IActionResult CheckIntegrity([FromBody] UserDto receivedUser)
        {
            try
            {
                var user = _mapper.Map<UserDto, User>(receivedUser);
                _usersService.CheckUserData(user);
                return Ok();
            }
            catch (AppException ex)
            {
                return Unauthorized();
            }
        }
    }
}
