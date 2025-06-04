using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Autenticacao.Models;
using Microsoft.IdentityModel.Tokens;

namespace Autenticacao.Services
{
    public class TokenGenerator
    {
        public string Generate(User user)
        {
            var ExpiresHours = 4;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = AddClaims(user),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstants.Secret)),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Expires = DateTime.UtcNow.AddHours(ExpiresHours)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private ClaimsIdentity AddClaims(User user)
        {
            var clains = new ClaimsIdentity();
            clains.AddClaim(new Claim(ClaimTypes.Email, user.Email!));
            clains.AddClaim(new Claim(ClaimTypes.Name, user.Name!));
            clains.AddClaim(new Claim(ClaimTypes.Role, user.Access!));
            return clains;
        }
    }
}