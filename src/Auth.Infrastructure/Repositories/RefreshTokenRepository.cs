using Auth.Domain.Entities.Auth.Tokens;
using Auth.Infrastructure.DbContext;
using Auth.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositories
{
    public class RefreshTokenRepository : RepsoitoryBase<UserRefreshToken, long>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(AuthDbContext dbContext) : base(dbContext)
        {
        }
    }
}
