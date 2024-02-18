using Auth.Application.Interfaces;
using Auth.Application.Validations;
using Auth.Domain.Dtos.RoleDto;
using Auth.Domain.Entities.Auth.Roles;
using Auth.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepsoitory roleRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public RoleService(IRoleRepsoitory roleRepository , IMapper mapper , IUnitOfWork unitOfWork )
        {
            this.roleRepository = roleRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async ValueTask<Role> AddRoleAsync(PostRoleDto role)
        {
            ObjectValidations.ObjectIsNull(role);
            var mapp = this.mapper.Map<Role>( role );
            var result = await this.roleRepository.AddAsync(mapp);
            await this.unitOfWork.SaveChangesAsync();
            return result;

        }

        public async ValueTask<Role> DeleteRoleAsync(long roleId)
        {
            ObjectValidations.ProportyIsNull(roleId);
            var byId = await this.roleRepository.GetByIdAsync(roleId);
            if( byId == null)
                throw new ArgumentNullException(nameof(roleId)+ "Not Found");
            var result = await this.roleRepository.RemoveAsync(byId);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public IQueryable<Role> GetAllRoles()
        {
            return this.roleRepository.GetAllAsQueryable();
        }

        public async ValueTask<Role> GetRoleByIdAsync(long roleId)
        {
            ObjectValidations.ProportyIsNull(roleId);

            var result = await this.roleRepository.GetByIdAsync(roleId);

            return result;
        }

        public async ValueTask<Role> UpdateRoleAsync(UpdateRoleDto role)
        {
            ObjectValidations.ObjectIsNull(role);

            var byId = await this.roleRepository.GetByIdAsync(role.Id);
            if(byId == null)
                throw new ArgumentNullException ($"{role.Id} does not exist");
            var result  = await this.roleRepository.UpdateAsync(byId);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}
