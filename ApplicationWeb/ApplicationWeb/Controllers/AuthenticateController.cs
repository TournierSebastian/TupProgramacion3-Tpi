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


    /// PROBANDO SI FUNCIONA EL AUTH DSP ORDENAR EN SUPERADMIN
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
        public IActionResult Login([FromBody] AuthenticationRequestBody authenticationRequestBody)
        {
            Tuple<bool, DtoUser?> validationResponse = _authService.ValidateUser(authenticationRequestBody.Email, authenticationRequestBody.Password);
            if (!validationResponse.Item1 && validationResponse.Item2 == null)
            {
                return NotFound("Email no existente");
            }
            else if (!validationResponse.Item1 && validationResponse.Item2 != null)
                return Unauthorized("Contraseña incorrecta");

            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", validationResponse.Item2.Email));
            claimsForToken.Add(new Claim("Username", validationResponse.Item2.UserName));
            claimsForToken.Add(new Claim("role", validationResponse.Item2.UserType)); // cambiar mas adelante

            var jwtToken = new JwtSecurityToken(
            _configuration["Authentication:Issuer"],
            _configuration["Authentication:Audience"],
            claimsForToken,
            DateTime.UtcNow,
            DateTime.UtcNow.AddHours(1),
            credentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtToken);

            return Ok(tokenToReturn);
        }

    }
}
