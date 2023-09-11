using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MentorshipWebApp.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private string _jwtIssuer = string.Empty;
        private string _jwtAudience = string.Empty;
        private string _jwtKey = string.Empty;

        public AccountController(IConfiguration configuration)
        {
            _jwtIssuer = configuration["Jwt:Issuer"];
            _jwtAudience = configuration["Jwt:Audience"];
            _jwtKey = configuration["Jwt:Key"];
        }

        [HttpPost]
        public IActionResult Login(string username, string password, string role)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && 
                !string.IsNullOrEmpty(role))
            {
                var issuer = _jwtIssuer;
                var audience = _jwtAudience;
                
                var key = Encoding.ASCII.GetBytes(_jwtKey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Name, username),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, role),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);
                
                return Ok(stringToken);
            }

            return Unauthorized();
        }

        [HttpPost("refresh")]
        public IActionResult RefreshToken(string accessToken, string refreshToken)
        {
            // ToDo: https://code-maze.com/using-refresh-tokens-in-asp-net-core-authentication/

            return Ok();
        }
    }
}
