using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using webapi.Business.Abstract;
using webapi.Models.Entities;
using webapi.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace webapi.Controllers {

    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase{
        
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) { 
            this._userRepository = userRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUsers() {
            IEnumerable<User> users = await this._userRepository.GetUsers();
            if(users == null) {
                return NotFound();
            }

            return Ok(users);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetUserById")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id) {

            var user = await this._userRepository.GetUserByID(id);
            
            if(user == null) {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddUser(User user) {
            user.Id = Guid.NewGuid();
            await this._userRepository.InsertUser(user);
            return Ok(user);
        }
    }
}
