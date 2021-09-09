using Log.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Log.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AppSettings _appsetting;

        public AuthenticationService(IOptions<AppSettings> appsetting)
        {
            _appsetting = appsetting.Value;
        }
        private readonly List<UserDeatils> users = new List<UserDeatils>()
        {
            new UserDeatils
            {
                ID=420,
                Name="Admin",
                Password="Password@123"
            }
        };
        public UserDeatils Authenticate(string username, string pass)
        {
            var user = users.SingleOrDefault(x => x.Name == username && x.Password == pass);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsetting.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V3.1")
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = null;
            return user;
        }
    }
}
