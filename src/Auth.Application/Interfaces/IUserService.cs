using Auth.Domain.Dtos.UserDto;
using Auth.Domain.Entities.Auth.Tokens;
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
        Task<GetUserDto> GetByIdAsync(long id);
        Task<IQueryable<GetAllUserDto>> GetAllAsync();
        Task<User?> GetByEmailAsync(string email);
        Task<User> RemoveUserAsync(DeleteUserDto user);
        Task<User> UpdateUserAsync(UpdateUserDto user);
        Task<User> CreateUserAsync(PostUserDto user);
        Task<UserToken> LoginUserAsync(UserCredentials userCredential);

    }
}
