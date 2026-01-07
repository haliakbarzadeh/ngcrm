using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NgCrm.BasicInfoService.Domain.Common.Models;
using NgCrm.BasicInfoService.Domain.Users.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NgCrm.BasicInfoService.Application.Users.Services
{
    public class TokenService : ITokenService
    {
        private readonly AppSetting _appSetting;

        public TokenService(IOptions<AppSetting> options)
        {
            _appSetting = options.Value;
        }

        public string CreateToken(string username, IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSetting.JwtConfig.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.Now;
            var expires = now.AddHours(_appSetting.JwtConfig.ExpiresHours);

            var allClaims = new List<Claim>
            {
                 new Claim("username", username),
            };

            if (claims != null) allClaims.AddRange(claims);

            var token = new JwtSecurityToken(
                issuer: _appSetting.JwtConfig.Issuer,
                audience: _appSetting.JwtConfig.Audience,
                claims: allClaims,
                notBefore: now,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
