using Microsoft.AspNetCore.Mvc;
using webapi.Business.Abstract;
using webapi.Models.DTO;
using webapi.Models.Entities;
using System.Diagnostics;
using Crypt = BCrypt.Net.BCrypt;
using System.Text.Json.Serialization;
using webapi.Business.Concrete;

namespace webapi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase{

        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;

        public AuthController(IAuthRepository authRepository, ITokenService tokenService) {
            this._authRepository = authRepository;
            this._tokenService = tokenService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegisterDTO) {
            
            if (this.ModelState.IsValid) {

                bool userExists = await this._authRepository.UserExists(userRegisterDTO);

                if(!userExists) {

                    // Hash Password
                    var hashedPassword = Crypt.HashPassword(userRegisterDTO.Password, 12);

                    User newUser = new User(Guid.NewGuid(), firstName: userRegisterDTO.FirstName, lastName: userRegisterDTO.LastName,
                        email: userRegisterDTO.Email, password: hashedPassword);

                    var res = await this._authRepository.Register(newUser);

                    return(Ok(res));

                } else {
                    return BadRequest("User Already Exists.");
                }
            } else { 
                return BadRequest(this.ModelState);
            }
            

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO) {

            if(!(userLoginDTO is UserLoginDTO)) {
                return BadRequest("Invalid Request Body");

            }

            if (this.ModelState.IsValid) {
                
                bool userExists = await this._authRepository.UserExistsLogin(userLoginDTO);

                if(userExists){
                    string token = this._tokenService.GenerateJWT(userLoginDTO); 
                    if(token  == null) {
                        return BadRequest();
                    }

                    return Ok(token);
                }
                else {
                    return Unauthorized("Email or Password does not match a User on record.");
                }
            }
            else {
                return BadRequest(this.ModelState);
            }

        }


    }
}
