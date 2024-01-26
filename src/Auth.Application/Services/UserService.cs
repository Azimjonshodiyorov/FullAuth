using Auth.Application.Interfaces;
using Auth.Application.MappingProfils;
using Auth.Domain.Dtos;
using Auth.Domain.Entities.Auth.Users;
using Auth.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Auth.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository , IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public async Task<User> CreateUserAsync(UserDto user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var map = this.mapper.Map<User>(user);

            var result = await this.userRepository.AddAsync(map);
            return result;
        }

        public async Task<IQueryable<User>> GetAllAsync()
        {
            return  this.userRepository.GetAllAsQueryable();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            if(email is null)
            {
                throw new ArgumentNullException(nameof(email));
            }    
          var result = await this.userRepository.GetAllAsQueryable().FirstOrDefaultAsync(x => EF.Functions.ILike(x.Email, email));
            return result;
        }

        public async Task<User> GetByIdAsync(long id)
        {
            if(id == 0)
            {
                throw new Exception($"Id is 0");
            }

            var result = await this.userRepository.GetByIdAsync(id);

            return result;
        }

        public Task<User> RemoveUserAsync(UserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserAsync(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
