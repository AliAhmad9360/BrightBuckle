using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid UserId,
        string FirstName,
        string MiddleName,
        string LastName,
        string Email,
        string Username,
        string Token
    );
}
