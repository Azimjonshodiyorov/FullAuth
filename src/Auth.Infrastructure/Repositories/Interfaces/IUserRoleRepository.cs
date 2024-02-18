using Auth.Domain.Entities.Auth.UserRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositories.Interfaces
{
    public interface IUserRoleRepository : IRepositoryBase<UserRole , long>
    {
    }
}
