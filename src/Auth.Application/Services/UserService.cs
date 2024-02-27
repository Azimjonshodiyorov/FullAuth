using Auth.Application.Interfaces;
using Auth.Application.Validations;
using Auth.Domain.Dtos.UserDto;
using Auth.Domain.Entities.Auth.Tokens;
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
        private readonly IJwtService jwtService;

        public UserService(IUserRepository userRepository , IMapper mapper , IUnitOfWork unitOfWork , IJwtService jwtService)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.jwtService = jwtService;
        }
        public async Task<User> CreateUserAsync(PostUserDto user)
        {
           ObjectValidations.ObjectIsNull(user);

            var map = this.mapper.Map<User>(user);

            var result = await this.userRepository.AddAsync(map);

            await this.unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<IQueryable<GetAllUserDto>> GetAllAsync()
        {
            var resu=  this.userRepository.GetAllAsQueryable();
            var result = this.mapper.Map<List<GetAllUserDto>>(resu.ToList());
            return result.AsQueryable();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            ObjectValidations.ProportyIsNull(email);   
          var result = await this.userRepository.GetAllAsQueryable().FirstOrDefaultAsync(x => EF.Functions.ILike(x.Email, email));
            return result;
        }

        public async Task<GetUserDto> GetByIdAsync(long id)
        {
            

            var result = await this.userRepository.GetByIdAsync(id);
            ObjectValidations.ObjectIsNull(result);
            var mapps = this.mapper.Map<GetUserDto>(result);

            return mapps;
        }

        public async Task<User> RemoveUserAsync(DeleteUserDto user)
        {
            ObjectValidations.ObjectIsNull(user);
            var mapps = this.mapper.Map<User>(user);
            var result = await this.userRepository.RemoveAsync(mapps);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<User> UpdateUserAsync(UpdateUserDto user)
        {
            ObjectValidations.ObjectIsNull(user);

            var mapp = this.mapper.Map<User>(user);

            var result = await this.userRepository.UpdateAsync(mapp);
            await this.unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<UserToken> LoginUserAsync(UserCredentials userCredential)
        {

           var user = await this.userRepository.GetAllAsQueryable()
                .FirstOrDefaultAsync(x=>x.Email == userCredential.Email && x.Password == userCredential.Password);

            ObjectValidations.ObjectIsNull(user);

              var result = await this.jwtService.GenerateRefreshToken(user);
             
            UserToken userToken = await this.jwtService.GenerateAccessTokens(user);


            return userToken;

        }



        /*public async Task<UserToken> RefreshTokenAsync(UserToken userToken)
        {

        }*/
    }
}
