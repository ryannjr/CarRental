using System;
using webapi.Models.Entities;
using webapi.Models.DTO;

namespace webapi.Business.Abstract
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserByID(Guid userId);
        Task<User> GetUserByEmail(string Email);
        Task<User> InsertUser(User user);
        /*
        Task<User> UpdateUser(User user);
        Task DeleteUser(Guid userId);
        */
        Task SaveDatabaseChanges();

    }
}
