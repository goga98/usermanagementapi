using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagement.Service.IServices;
using UserManagement.Shared.Models.UserDtos;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices _userService;
        public AuthController(IUserServices userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost, Route("login")]
        public IActionResult Login(LoginDto model)
        {
            if (model == null)
            {
                return BadRequest("Invalid client request");
            }
            if (!_userService.IsExist(model))
            {
                return Unauthorized();
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("A0UHENWERQIRXc6umqTfuBy2D8BWsJW2"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "GG",
                audience: "https://localhost:5019",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new { Token = tokenString });

        }
    }
}
