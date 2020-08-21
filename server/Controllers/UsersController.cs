using Microsoft.AspNetCore.Mvc;

using WebApi.Services;
using WebApi.Entities;
using WebApi.Models;
using WebApi.Helpers;
using Microsoft.Extensions.Options;

using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

using System;
using System.Text;

using AutoMapper;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
       
        public UsersController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect" });

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
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                user.Id,
                user.Email,
                user.FirstName,
                user.LastName,
                Token = tokenString
            });
        }

        // [Authorize(Roles = Role.Admin)]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users =  _userService.GetAll();
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // only allow admins to access other user records
            //var currentUserId = int.TryParse(User.Identity.Name, out number);
            //if (id != currentUserId && !User.IsInRole(Role.Admin))
            //    return Forbid();

            var user =  _userService.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            // map model to entity
            var user = _mapper.Map<User>(model);

            try
            {
                // create user
                _userService.Create(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
