using Auth.Domain.Dtos;
using Auth.Domain.Entities.Auth.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(long id);
        Task<IQueryable<User>> GetAllAsync();
        Task<User?> GetByEmailAsync(string email);
        Task<User> RemoveUserAsync(UserDto user);
        Task<User> UpdateUserAsync(UserDto user);
        Task<User> CreateUserAsync(UserDto user);

    }
}
