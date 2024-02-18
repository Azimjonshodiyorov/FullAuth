using Auth.Application.Interfaces;
using Auth.Application.Validations;
using Auth.Domain.Dtos.UserRoleDto;
using Auth.Domain.Entities.Auth.UserRoles;
using Auth.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UserRoleService(IUserRoleRepository userRoleRepository , IMapper mapper , IUnitOfWork unitOfWork)
        {
            this.userRoleRepository = userRoleRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async ValueTask<UserRole> AddUserRoleAsync(PostUserRoleDto userRole)
        {
            ObjectValidations.ObjectIsNull(userRole);
            var mapUserRole = this.mapper.Map<UserRole>(userRole);
            var result = await this.userRoleRepository.AddAsync(mapUserRole);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public async ValueTask<UserRole> DeleteUserRoleAsync(long userRoleId)
        {
            ObjectValidations.ProportyIsNull(userRoleId);

            var result = await this.userRoleRepository
                .Include(x=>x.User)
                .Include(x=>x.Role)
                .FirstOrDefaultAsync(x=>x.Id.Equals(userRoleId));
            if (result == null)
                ObjectValidations.ObjectIsNull(result);

            await this.unitOfWork.SaveChangesAsync();

            return result;
        }

        public IQueryable<UserRole> GetAllUserRoles()
        {
            var result = this.userRoleRepository
                .Include(x=>x.User)
                .Include(x=>x.Role)
                .AsQueryable();

            return result;
        }

        public async ValueTask<UserRole> GetUserRoleByIdAsync(long userRoleId)
        {
            ObjectValidations.ProportyIsNull(userRoleId);

            var result = await this.userRoleRepository
                .Include(x=>x.User)
                .Include(x=>x.Role)
                .AsQueryable().FirstOrDefaultAsync(x=>x.Id == userRoleId);
            return result;
        }

        public async ValueTask<UserRole> UpdateUserRoleAsync(UpdateUserRoleDto userRole)
        {
            ObjectValidations.ObjectIsNull(userRole);

            var mappUpdate = this.mapper.Map<UserRole>(userRole);

            var result= await this.userRoleRepository.UpdateAsync(mappUpdate);
            await this
                .unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}
