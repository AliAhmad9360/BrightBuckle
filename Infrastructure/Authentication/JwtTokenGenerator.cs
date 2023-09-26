using Application.Common.Interfaces.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings){
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken( Guid UserId, string FirstName, string LastName, string Email )
        {
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256
            ) ;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, Email),
                new Claim(JwtRegisteredClaimNames.GivenName, FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, LastName)
            };

            var jwtSecurityToken = new JwtSecurityToken(
                claims: claims, 
                signingCredentials: credentials, 
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.Now.AddDays(_jwtSettings.ExpiryMinutes)
            );
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
