using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Helpers;
using TeslaGoAPI.Logic.Identity.Services.Interfaces;

namespace TeslaGoAPI.Logic.Identity.Services.Services
{
    public class JWTGeneratorService : IJWTGeneratorService
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;

        public JWTGeneratorService(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JWTSettings");
        }

        public string GenerateToken(User user, IList<string>? roles)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaimsForUser(user, roles);
            var tokenOptions = GetTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings["securityKey"]!);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private List<Claim> GetClaimsForUser(User user, IList<string>? roles)
        {
            var claims = new List<Claim>
            {
                new("id", user.Id.ToString()),
                new("name", user.Name!),
                new("surname", user.Surname!),
                new("emailAddress", user.Email!),
            };
            if (roles != null)
            {
                foreach (var role in roles)
                    claims.Add(new Claim("userRoles", role));
            }


            return claims;
        }

        private JwtSecurityToken GetTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            return new JwtSecurityToken(
                issuer: _jwtSettings["validIssuer"],
                audience: _jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings["expiryInMinutes"])),
                signingCredentials: signingCredentials
            );
        }

    }
}
