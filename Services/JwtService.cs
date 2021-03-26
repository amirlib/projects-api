using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectsApi.Helpers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ProjectsApi.Services
{
    public class JwtService : IJwtService
    {
        public JwtService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        #region Fields
        private readonly AppSettings _appSettings;
        #endregion

        #region Public Methods
        public string DecodeSecurityToken(string authorizationValue)
        {
            var token = authorizationValue.ToString().Split(" ");

            if (token.Length < 2) return null;

            var handler = new JwtSecurityTokenHandler();
            var data = handler.ReadJwtToken(token[1]);
            var idClaim = data.Claims.FirstOrDefault(claim => claim.Type == "unique_name");

            if (idClaim is null) return null;

            return idClaim.Value;
        }

        public string GenerateSecurityToken(string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id)
                }),
                Expires = DateTime.UtcNow.AddDays(_appSettings.ExpiresDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        #endregion
    }
}
