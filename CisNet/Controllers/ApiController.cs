using CisNet.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CisNet.Types;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;

namespace CisNet.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : Controller
    {
        private readonly ModelDb _model;
        private Config _config;

        public ApiController(IConfiguration config)
        {
            Connect con = new Connect()
            {
                UserName = config.GetConnectionString("UserName"),
                Password = config.GetConnectionString("Password"),
                DataSource = config.GetConnectionString("DataSource")
            };
            _model = new ModelDb(con);
            _config = new Config() { Secret = config.GetValue<string>("JWTSecret:Secret") };
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Index Test Ok");
        }

        [HttpPost("Loginnet")]
        public async Task<IActionResult> Validate([FromBody]UserInfo userInfo)
        {
            if (_model.CheckUser(userInfo.Username, userInfo.Password))
            {
                return Ok(new RegistrtionResponce()
                {
                    Success = true,
                    Username = userInfo.Username,
                    Token = GenerateJwtToken(userInfo)
                });
            }
            return Problem("Ошибка! Пользователь не определен или ошибка при вводе пароля!");
        }

        private string GenerateJwtToken(UserInfo userInfo)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { 
                    new Claim("Id", "228"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
