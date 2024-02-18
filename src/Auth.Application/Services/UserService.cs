using Auth.Application.Interfaces;
using Auth.Application.MappingProfils;
using Auth.Application.Validations;
using Auth.Domain.Dtos.UserDto;
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
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository userRepository , IMapper mapper , IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<User> CreateUserAsync(UserDto user)
        {
           ObjectValidations.ObjectIsNull(user);

            var map = this.mapper.Map<User>(user);

            var result = await this.userRepository.AddAsync(map);

            await this.unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<IQueryable<User>> GetAllAsync()
        {
            return  this.userRepository.GetAllAsQueryable();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            ObjectValidations.ProportyIsNull(email);   
          var result = await this.userRepository.GetAllAsQueryable().FirstOrDefaultAsync(x => EF.Functions.ILike(x.Email, email));
            return result;
        }

        public async Task<User> GetByIdAsync(long id)
        {
            ObjectValidations.ProportyIsNull(id);

            var result = await this.userRepository.GetByIdAsync(id);

            return result;
        }

        public async Task<User> RemoveUserAsync(UserDto user)
        {
            ObjectValidations.ObjectIsNull<UserDto>(user);
            var mapps = this.mapper.Map<User>(user);
            var result = await this.userRepository.RemoveAsync(mapps);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<User> UpdateUserAsync(UserDto user)
        {
            ObjectValidations.ObjectIsNull(user);

            var mapp = this.mapper.Map<User>(user);

            var result = await this.userRepository.UpdateAsync(mapp);
            await this.unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
