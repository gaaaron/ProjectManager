using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using ProjectManager.Model.Services;
using ProjectManager.RestApi.Dtos;
using ProjectManager.RestApi.Models;
using ProjectManager.Model.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUserService _userService;
        private readonly AppSettings _appSettings;

        public UsersController(IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateDto model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            // return null if user not found
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = tokenHandler.WriteToken(token);

            return Ok(userDto);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterDto model)
        {
            // map model to entity
            var user = _mapper.Map<User>(model);

            // create user
            _userService.Create(user);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.GetAllReduced();
            return Ok(_mapper.Map<List<ReducedUserDto>>(users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.Get(id);
            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpGet("names")]
        public IActionResult GetUserNames()
        {
            var userNames = _userService.GetAll().Select(u => u.UserName);
            return Ok(userNames.ToList());
        }
    }
}