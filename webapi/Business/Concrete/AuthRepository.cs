using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using webapi.Business.Abstract;
using webapi.Contexts;
using webapi.Models.DTO;
using webapi.Models.Entities;
using Bcrypt = BCrypt.Net.BCrypt;

namespace webapi.Business.Concrete {
    public class AuthRepository : IAuthRepository {

        private CarRentalDbContext _context;

        public AuthRepository(CarRentalDbContext context) {
            this._context = context;
        }

        public Task<User> Login(UserLoginDTO userLoginDTO) {
            var user = this._context.Users.Where(u => u.Email.ToLower() == userLoginDTO.Email.ToLower());
            return null;
        }

        public async Task<User> Register(User user) {
            var result = await this._context.Users.AddAsync(user);
            await this._context.SaveChangesAsync();
            return result.Entity;
        }


        public async Task<bool> UserExists(UserRegisterDTO user) {
            var exists = await this._context.Users.Where(u => u.Email == user.Email).FirstOrDefaultAsync();
            return exists != null;
        }

        public async Task<bool> UserExistsLogin(UserLoginDTO user) {
            var exists = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (exists == null) {
                return false;
            }
            else {
                if (Bcrypt.Verify(user.Password, exists.Password)) {
                    return true;
                }
                return false;
            }
        }
    }
}
