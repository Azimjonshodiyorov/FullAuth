using Auth.Domain.Entities.Auth.UserRoles;
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
    public class UserRoleRepository : RepositoryBase<UserRole, long>, IUserRoleRepository
    {
        public UserRoleRepository(AuthDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
