using System;
using System.Text;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Back_end.DatabaseModels;

namespace Back_end.Controllers
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string key;
        private readonly CookifyContext _context;
        public JwtAuthenticationManager(string key, CookifyContext context)
        {
            this.key = key;
            this._context = context;
        }

        public string Authenticate(string email)
        {
            if (!_context.Users.Any(u=>u.Email == email))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);

            Claim claims;
            if((bool)_context.Users.Where(x => x.Email == email).Select(k=>k.Admin).FirstOrDefault())
                claims = new Claim("type","Admin");
            else 
                claims = new Claim("type","User");


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    claims

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