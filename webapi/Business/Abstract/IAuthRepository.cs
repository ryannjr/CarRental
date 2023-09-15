using Microsoft.AspNetCore.Mvc;
using webapi.Models.DTO;
using webapi.Models.Entities;

namespace webapi.Business.Abstract {
    public interface IAuthRepository {
        
        Task<User> Register(User userRegisterDTO);
        Task<User> Login(UserLoginDTO userLoginDTO);

        Task<bool> UserExists(UserRegisterDTO user);
        
        Task<bool> UserExistsLogin(UserLoginDTO user);
    }
}
