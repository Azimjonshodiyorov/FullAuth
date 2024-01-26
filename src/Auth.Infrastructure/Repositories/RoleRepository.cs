using Auth.Domain.Entities.Auth.Roles;
using Auth.Infrastructure.DbContexts;
using Auth.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositories
{
    public class RoleRepository : RepsoitoryBase<Role, long>, IRoleRepsoitory
    {
        public RoleRepository(AuthDbContext dbContext) : base(dbContext)
        {
        }
    }
}
