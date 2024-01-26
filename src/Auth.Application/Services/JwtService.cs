using Auth.Application.Interfaces;
using Auth.Domain.Entities.Auth.RolePermissions;
using Auth.Domain.Entities.Auth.Roles;
using Auth.Domain.Entities.Auth.Tokens;
using Auth.Domain.Entities.Auth.UserRoles;
using Auth.Domain.Entities.Auth.Users;
using Auth.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Services
{
    public class JwtService : IJwtService
    {
        private readonly IUserRepository userRepository;
        private readonly IConfiguration configuration;
        private readonly IOptions<JwtOptions> _option;

        public JwtService(IUserRepository userRepository , IConfiguration configuration, IOptions<JwtOptions> option)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
            this._option = option;
        }

        public async Task<UserToken?> GenerateAccessTokens(User user)
        {
           var result =  this.userRepository.GetAllAsQueryable().Where(x=>x.FirstName == user.FirstName 
           && x.LastName == user.LastName && x.PhoneNumber ==user.PhoneNumber
           && x.Email == user.Email)
                ?.Include(x=>x.UserRoles)
                .ThenInclude(x=>x.Role)
                .ThenInclude(x=>x.RolePermissions)
                .ThenInclude(x=>x.Permission)
                .Select(x=>x)
                .FirstOrDefaultAsync();

            if(result == null)
                return null;
            IEnumerable<Role?> roles = user.UserRoles.Select(x=>x.Role);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName, user.LastName),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
            };

            List<string> permissions = new List<string>();

            foreach (UserRole role in user.UserRoles)
            {
                foreach (RolePermission permission in role.Role.RolePermissions)
                {
                    permissions.Add(permission.Permission.Name.ToString());
                }
            }


            permissions = permissions.Distinct().ToList();

            foreach (var item in permissions)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_option.Value.SecretKey));
            var signingCredentials = new SigningCredentials(signingKey , SecurityAlgorithms.HmacSha256);
            int.TryParse(configuration["Jwt:RefreshTokenLifetime"], out int lifetime);

            SecurityToken securityToken = new JwtSecurityToken(
                issuer: _option.Value.Issuer,
                audience: _option.Value.Audience,
                expires:DateTime.Now.AddMinutes(lifetime),
                claims:claims,
                signingCredentials:signingCredentials) ;

            var accessToken = new JwtSecurityTokenHandler().WriteToken(securityToken);
            var refreshToken = GenerateRefreshToken();

            return new UserToken() { AccessToken = accessToken, RefreshToken = refreshToken };
        }

        public async Task<UserToken?>  GenerateRefreshToken(User user)
        {
            var result = this.userRepository.GetAllAsQueryable().Where(x => x.FirstName == user.FirstName
            && x.LastName == user.LastName && x.PhoneNumber == user.PhoneNumber
            && x.Email == user.Email)
                 ?.Include(x => x.UserRoles)
                 .ThenInclude(x => x.Role)
                 .ThenInclude(x => x.RolePermissions)
                 .ThenInclude(x => x.Permission)
                 .Select(x => x)
                 .FirstOrDefaultAsync();

            if (result == null)
                return null;
            IEnumerable<Role?> roles = user.UserRoles.Select(x => x.Role);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName, user.LastName),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
            };

            List<string> permissions = new List<string>();

            foreach (UserRole role in user.UserRoles)
            {
                foreach (RolePermission permission in role.Role.RolePermissions)
                {
                    permissions.Add(permission.Permission.Name.ToString());
                }
            }


            permissions = permissions.Distinct().ToList();

            foreach (var item in permissions)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_option.Value.SecretKey));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            int.TryParse(configuration["Jwt:RefreshTokenLifetime"], out int lifetime);

            SecurityToken securityToken = new JwtSecurityToken(
                issuer: _option.Value.Issuer,
                audience: _option.Value.Audience,
                expires: DateTime.Now.AddMinutes(lifetime),
                claims: claims,
                signingCredentials: signingCredentials);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(securityToken);
            var refreshToken = GenerateRefreshToken();

            return new UserToken() { AccessToken = accessToken, RefreshToken = refreshToken };
        }

        public async Task<ClaimsPrincipal?>  GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidAudience = _option.Value.Audience,
                ValidIssuer = _option.Value.Issuer,
                RequireExpirationTime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_option.Value.SecretKey))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principall = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }

            return principall;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new Byte[32];
            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
