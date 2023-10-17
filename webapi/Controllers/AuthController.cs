using Microsoft.AspNetCore.Mvc;
using webapi.Business.Abstract;
using webapi.Models.DTO;
using webapi.Models.Entities;
using System.Diagnostics;
using Crypt = BCrypt.Net.BCrypt;
using System.Text.Json.Serialization;
using webapi.Business.Concrete;
using webapi.Business.Responses;
using System.IdentityModel.Tokens.Jwt;

namespace webapi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase{

        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthController(IAuthRepository authRepository, ITokenService tokenService, IUserRepository userRepository) {
            this._authRepository = authRepository;
            this._userRepository = userRepository;
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
                    var user = this._userRepository.GetUserByEmail(userLoginDTO.Email).Result;

                    string token = this._tokenService.GenerateJWT(user);
                    string refreshToken = this._tokenService.GenerateRefreshToken(user);
                    if(token  == null) {
                        return BadRequest();
                    }

                    return Ok(new LoginResponse()
                    {
                        user = user,
                        accessToken = token,
                        refreshToken = refreshToken
                    }) ;
                }
                else {
                    return Unauthorized("Email or Password does not match a User on record.");
                }
            }
            else {
                return BadRequest(this.ModelState);
            }

        }

        [HttpPost]
        [Route("verify")]
        public bool VerifyToken([FromBody] RefreshTokenDTO token) {
            return _tokenService.VerifyAccessToken(token.RefreshToken);
        }

        
        [HttpPost]
        [Route("refresh")]

        public async Task<IActionResult> Refresh([FromBody] RefreshTokenDTO refreshTokenDTO) {
            if (!ModelState.IsValid) { return BadRequest(); }

            bool isValidToken = this._tokenService.VerifyRefreshToken(refreshTokenDTO.RefreshToken);
            if (!isValidToken) {
                return BadRequest(new ErrorResponse("Invalid Refresh Token"));
            }
            var handler = new JwtSecurityTokenHandler();
            var decoded = handler.ReadJwtToken(refreshTokenDTO.RefreshToken);

            Guid uID = Guid.Parse(decoded.Claims.First(claim => claim.Type == "userID").Value);
            User user = await this._userRepository.GetUserByID(uID);
            
            // Generate new tokens
            string accessToken = _tokenService.GenerateJWT(user);
            string refreshToken = _tokenService.GenerateRefreshToken(user);

            return Ok(new LoginResponse()
            {
                user = user,
                accessToken = accessToken,
                refreshToken = refreshToken
            });
        }
        

    }
}
