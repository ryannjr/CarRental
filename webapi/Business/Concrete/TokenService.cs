using Microsoft.IdentityModel.Tokens;
using System.Text;
using webapi.Business.Abstract;
using Microsoft.Extensions.Configuration;
using webapi.Models.Entities;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using webapi.Models.DTO;
using webapi.Contexts;
using System.Security.Cryptography;

namespace webapi.Business.Concrete {
    public class TokenService : ITokenService {

        private CarRentalDbContext _context;
        public TokenService(CarRentalDbContext context) {
            _context = context;
        }
        public string GenerateJWT(User user) {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var secret = config.GetValue<string>("JWT:Secret_Key");
            var issuer = config.GetValue<string>("JWT:Issuer");
            var audience = config.GetValue<string>("JWT:Audience");

            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            string algorithm = SecurityAlgorithms.HmacSha256;
            
            SigningCredentials credentials = new SigningCredentials(key, algorithm);

            string role = user.isAdmin ? "Admin" : "User";

            List<Claim> claims = new List<Claim>
            {
                new Claim("userID", user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, role),
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(15),
                claims: claims,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public string GenerateRefreshToken(User user) {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var secret = config.GetValue<string>("JWT:Refresh_Secret_Key");
            var issuer = config.GetValue<string>("JWT:Issuer");
            var audience = config.GetValue<string>("JWT:Audience");

            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            string algorithm = SecurityAlgorithms.HmacSha256;
            SigningCredentials credentials = new SigningCredentials(key, algorithm);

            List<Claim> claims = new List<Claim>
            {
                new Claim("userID", user.Id.ToString()),
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer = issuer,
                audience = audience,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMonths(1),
                claims: claims,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool VerifyRefreshToken(string token) {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var secret = config.GetValue<string>("JWT:Refresh_Secret_Key");
            var issuer = config.GetValue<string>("JWT:Issuer");
            var audience = config.GetValue<string>("JWT:Audience");

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            TokenValidationParameters parameters = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                ValidIssuer = issuer,
                ValidAudience = audience,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ClockSkew = TimeSpan.Zero,

            };

            try {
                handler.ValidateToken(token, parameters, out SecurityToken validatedToken);
                return true;

            }
            catch (Exception) {
                return false;
            }
        }

        public bool VerifyAccessToken(string token) {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var secret = config.GetValue<string>("JWT:Secret_Key");
            var issuer = config.GetValue<string>("JWT:Issuer");
            var audience = config.GetValue<string>("JWT:Audience");

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            TokenValidationParameters parameters = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                ValidIssuer = issuer,
                ValidAudience = audience,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ClockSkew = TimeSpan.Zero,

            };

            try {
                handler.ValidateToken(token, parameters, out SecurityToken validatedToken);
                return true;

            }
            catch (Exception) {
                return false;
            }
        }
    }
}
