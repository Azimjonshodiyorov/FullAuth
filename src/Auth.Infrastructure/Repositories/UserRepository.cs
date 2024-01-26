using Auth.Domain.Entities.Auth.Users;
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
    public class UserRepository : RepsoitoryBase<User, long>, IUserRepository
    {
        public UserRepository(AuthDbContext dbContext) : base(dbContext)
        {
        }
    }
}
