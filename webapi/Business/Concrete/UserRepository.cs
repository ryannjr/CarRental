using Microsoft.EntityFrameworkCore;
using System;
using webapi.Contexts;
using webapi.Business.Abstract;
using webapi.Models.Entities;

namespace webapi.Business.Concrete
{
    public class UserRepository : IUserRepository
    {

        private CarRentalDbContext _context;

        public UserRepository(CarRentalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await this._context.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUserByID(Guid userId)
        {
            return await this._context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<User> InsertUser(User user) {
            var result = await this._context.Users.AddAsync(user);
            await SaveDatabaseChanges();

            return result.Entity;
        }
        /*
        public async Task<User> UpdateUser(User user)
        {
            var found = await this._context.Users.FindAsync(user.Id);


        }

        public void DeleteUser(int userId)
        {
            User? user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }
        */
        public async Task SaveDatabaseChanges()
        {
            await this._context.SaveChangesAsync();
        }
    }
}
