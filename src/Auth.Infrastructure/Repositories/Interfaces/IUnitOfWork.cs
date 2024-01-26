using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IProductRepository Products { get; }
        IRefreshTokenRepository RefreshTokens { get; }
        IRoleRepsoitory Roles { get; }
        Task SaveChangesAsync();
        void SaveChanges();

        IDbTransaction BeginTransaction();
    }
}
