using webapi.Models.DTO;
using webapi.Models.Entities;

namespace webapi.Business.Abstract {
    public interface ITokenService {
        string GenerateJWT(User user);

        string GenerateRefreshToken(User user);

        bool VerifyAccessToken(string token);
        bool VerifyRefreshToken(string token);
    }
}
