using System;
using System.Text;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Back_end.Data;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Back_end.Controllers
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly MockUserRepo mockUserRepo = new MockUserRepo();
        private readonly string key;
        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }

        public string Authenticate(string email)
        {
            if (!mockUserRepo.UserRepo.Any(u => u.email == email))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email , email)

                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                                         SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}