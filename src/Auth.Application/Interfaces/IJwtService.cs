using Auth.Domain.Entities.Auth.Tokens;
using Auth.Domain.Entities.Auth.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Interfaces
{
    public interface IJwtService
    {
       Task<UserToken?> GenerateAccessTokens(User user);
       Task<UserToken?> GenerateRefreshToken(User user);
       Task<ClaimsPrincipal?> GetPrincipalFromExpiredToken(string token);


    }
}
