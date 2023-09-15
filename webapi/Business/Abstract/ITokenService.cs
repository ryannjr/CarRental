using webapi.Models.DTO;
using webapi.Models.Entities;

namespace webapi.Business.Abstract {
    public interface ITokenService {
        string GenerateJWT(UserLoginDTO user);

        bool VerifyJWT(string token, string email);
    }
}
