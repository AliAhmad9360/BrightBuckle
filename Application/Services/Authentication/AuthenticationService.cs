using Application.Common.Interfaces.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _tokenGenerator;
        public AuthenticationService(IJwtTokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        public AuthenticationResult Login( string Username, string Password)
        {
            return new AuthenticationResult(Guid.NewGuid(), "First Name", "Middle Name", "Last Name", "Email", "Username", "token");
        }

        public AuthenticationResult Register(string FirstName,
            string MiddleName,
            string LastName,
            DateTime DateOfBirth,
            string Email,
            int Age,
            string PhoneNumber,
            string ZipCode,
            string Username,
            string Password)
        {
            string token = _tokenGenerator.GenerateToken( Guid.NewGuid(), FirstName, LastName, Email );
            return new AuthenticationResult(Guid.NewGuid(), "First Name", "Middle Name", "Last Name", "Email", "Username", token);
        }
    }
}
