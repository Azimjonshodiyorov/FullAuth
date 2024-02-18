using Auth.Domain.Entities.Auth.Permissions;
using Auth.Infrastructure.DbContexts;
using Auth.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Repositories
{
    public class PermissionRepository : RepositoryBase<Permission, long> ,IPermissionRepository 
    {
        public PermissionRepository(AuthDbContext dbContext) : base(dbContext)
        {
        }
    }
}
