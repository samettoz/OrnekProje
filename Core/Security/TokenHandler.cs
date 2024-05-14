using Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateToken()
        {

            Token token = new Token();

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.Now.AddMinutes(Convert.ToInt16(_configuration["Token:Expiration"]));

           


            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                expires: token.Expiration,
                notBefore: DateTime.Now,
                
                signingCredentials: credentials
                
                );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            token.RefreshToken = CreateRefreshToken();
            token.RefreshTokenExpiration = token.Expiration.AddHours(1);
            return token;

        }

        public string CreateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }

        }
    }
}
