using Microsoft.IdentityModel.Tokens;
using System.Text;
using webapi.Business.Abstract;
using Microsoft.Extensions.Configuration;
using webapi.Models.Entities;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using webapi.Models.DTO;

namespace webapi.Business.Concrete {
    public class TokenService : ITokenService {

        public string GenerateJWT(UserLoginDTO user) {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var secret = config.GetValue<string>("JWT:Secret_Key");
            var issuer = config.GetValue<string>("JWT:Issuer");
            var audience = config.GetValue<string>("JWT:Audience");

            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            string algorithm = SecurityAlgorithms.HmacSha256;
            
            SigningCredentials credentials = new SigningCredentials(key, algorithm);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddMinutes(30),
                claims: claims,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }


        public bool VerifyJWT(string token, string email) {
            if (token == null) return false;

            return true;
        }
    }
}
