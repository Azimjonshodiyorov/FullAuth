using Auth.Application.Interfaces;
using Auth.Application.Validations;
using Auth.Domain.ApiExceptions;
using Auth.Domain.Dtos.PermissionsDto;
using Auth.Domain.Entities.Auth.Permissions;
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
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository permissionRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PermissionService(IPermissionRepository permissionRepository , IMapper mapper , IUnitOfWork unitOfWork)
        {
            this.permissionRepository = permissionRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async ValueTask<Permission> AddPermissionAsync(PostPermissionDto permission)
        {
            ObjectValidations.ObjectIsNull(permission);

            var mapp = this.mapper.Map<Permission>(permission);
            var result = await this.permissionRepository.AddAsync(mapp);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public async ValueTask<Permission> DeletePermissionAsync(long permissionId)
        {
            var result = await this.permissionRepository.GetByIdAsync(permissionId);
            ObjectValidations.ProportyIsNull(result);
            var res = await this.permissionRepository.RemoveAsync(result);
            await this.unitOfWork.SaveChangesAsync();
             return res;
        }

        public IQueryable<Permission> GetAllPermissions()
        {
            return this.permissionRepository.GetAllAsQueryable();
        }

        public async ValueTask<Permission> GetPermissionByIdAsync(long permissionId)
        {
            var resultById = await this.permissionRepository.GetByIdAsync(id: permissionId);
            if(resultById == null)
                throw new ArgumentNullException(nameof(resultById)+" Not found id");

            return resultById;
        }

        public async ValueTask<Permission> UpdatePermissionAsync(UpdatePermissionDto permission)
        {
            ObjectValidations.ObjectIsNull(permission);

            var byId = await this.permissionRepository.GetByIdAsync(permission.Id);
            if(byId == null)
                throw new ArgumentNullException($"{permission.Id} already exists");

            var mapp = this.mapper.Map<Permission>(byId);

            var result = await this.permissionRepository.UpdateAsync(mapp);

            await this.unitOfWork.SaveChangesAsync();

            return result;


        }
    }
}
