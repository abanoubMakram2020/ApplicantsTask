
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using SharedKernal.Common.Enum;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SharedKernal.Middlewares.JWTSettings
{
    public class UserClaim
    {
        public SecurityEnum.TokenInfo Name { get; set; }
        public string Value { get; set; }
    }
    public interface ITokenHandler
    {
        string CreateToken(List<UserClaim> userClaims, SecurityEnum.Audiance audience);
        string GetTokenData(SecurityEnum.TokenInfo tokenInfo, ClaimsPrincipal user);
        List<Claim> GetTokenData(HttpRequest httpRequest);
        bool IsValidToken(string token);
    }

    public class TokenHandler : ITokenHandler
    {
        #region Methods
        public string CreateToken(List<UserClaim> userClaims, SecurityEnum.Audiance audience)
        {
            string audianceUrls = string.Empty;

        
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(JwtSettings.SecurityKey);

            List<Claim> claims = new List<Claim>();
            if (userClaims?.Count > default(int))
            {
                claims = userClaims.Select(x => new Claim(x.Name.ToString(), x.Value)).ToList();
            }

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(JwtSettings.ExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                IssuedAt = DateTime.Now,
                Issuer = JwtSettings.ValidIssuer,
                Audience = JwtSettings.ValidAudience
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
        public string GetTokenData(SecurityEnum.TokenInfo tokenInfo, ClaimsPrincipal user)
        {
            Claim userIdClaim = user.Claims.FirstOrDefault(x => x.Type == tokenInfo.ToString());
            return userIdClaim != null ? userIdClaim.Value : string.Empty;
        }
        public List<Claim> GetTokenData(HttpRequest httpRequest)
        {
            List<Claim> tokenData = null;
            if (httpRequest.Headers.ContainsKey("Authorization"))
            {
                var header = System.Net.Http.Headers.AuthenticationHeaderValue.Parse(httpRequest.Headers["Authorization"]);
                if (header != null)
                {
                    tokenData = new JwtSecurityTokenHandler().ReadJwtToken(header.Parameter).Claims.ToList();
                }
            }
            return tokenData;
        }
        public bool IsValidToken(string token)
        {
            return true;
        }
        #endregion
    }

}
