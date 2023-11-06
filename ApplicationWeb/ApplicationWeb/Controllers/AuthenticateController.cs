using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.IService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



namespace AplicacionWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthService _authService;
        public IConfiguration _configuration;
        public AuthenticateController(IAuthService authService, IConfiguration config)
        {
            _authService = authService;
            _configuration = config;
        }

        [HttpPost]
        public IActionResult Login([FromBody] DtoCredentials credentialsDto)
        {
            BaseResponse validationResponse = _authService.ValidateUser(credentialsDto.Email, credentialsDto.Password);
            if (validationResponse.Message == "wrong email")
            {
                return BadRequest(validationResponse.Message);
            }
            else if (validationResponse.Message == "wrong password")
            {
                return Unauthorized("wrong password");
            }
            if (validationResponse.Result)
            {
                DtoUser user = _authService.GetByEmail(credentialsDto.Email);


                var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
                var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim("sub", user.Email));
                claimsForToken.Add(new Claim("Username", user.UserName));
                claimsForToken.Add(new Claim("role", user.UserType));

                var jwtToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                credentials);

                var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtToken);

                return Ok(tokenToReturn);
            }
            return BadRequest();
        }
    }
}
