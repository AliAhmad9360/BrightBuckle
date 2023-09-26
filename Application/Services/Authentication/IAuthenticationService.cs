namespace Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Login(string Username, string Password);
        AuthenticationResult Register(
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
}
