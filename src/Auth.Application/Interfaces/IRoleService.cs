using Auth.Domain.Dtos.RoleDto;
using Auth.Domain.Entities.Auth.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Interfaces
{
    public interface IRoleService
    {
        ValueTask<Role> AddRoleAsync(PostRoleDto role);
        ValueTask<Role> GetRoleByIdAsync(long roleId);
        IQueryable<Role> GetAllRoles();
        ValueTask<Role> UpdateRoleAsync(UpdateRoleDto role);
        ValueTask<Role> DeleteRoleAsync(long roleId);
    }
}
