using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagement.Configurations;
using UserManagement.Models;
using UserManagement.Repositories;

namespace UserManagement.Services
{
    public class JwtTokenService : IJwtTokenGenerator
    {
        private readonly JwtConfiguration _jwtConfiguration;
        public JwtTokenService(IOptions<JwtConfiguration> jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration.Value;
        }
        public string GenerateToken(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtConfiguration.SecretKey);
            var listOfClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Name,user.Name),
                new Claim(JwtRegisteredClaimNames.Sub,user.RoleId.ToString()),
            };
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Audience = _jwtConfiguration.Audience,
                Issuer = _jwtConfiguration.Issuer,
                Subject = new ClaimsIdentity(listOfClaims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
