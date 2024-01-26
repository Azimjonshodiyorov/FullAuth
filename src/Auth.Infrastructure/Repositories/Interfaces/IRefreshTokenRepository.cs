using Auth.Domain.Entities.Auth.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositories.Interfaces
{
    public interface IRefreshTokenRepository :  IRepositoryBase<UserRefreshToken , long>
    {
    }
}
