using Auth.Domain.Entities.Auth.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositories.Interfaces
{
    public interface IPermissionRepository : IRepositoryBase<Permission , long>
    {
    }
}
