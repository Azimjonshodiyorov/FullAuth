using Auth.Domain.Entities.Auth.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositories.Interfaces
{
    public interface IRoleRepsoitory : IRepositoryBase<Role , long>
    {
    }
}
