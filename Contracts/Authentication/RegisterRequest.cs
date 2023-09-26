using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Authentication
{
    public record RegisterRequest(
        string FirstName,
        string MiddleName,
        string LastName, 
        DateTime DateOfBirth,
        string Email,
        int Age,
        string PhoneNumber,
        string ZipCode,
        string Username,
        string Password
    );
}
