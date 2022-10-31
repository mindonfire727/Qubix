using Qubix.Application.Common.Interfaces.Authentication;

namespace Qubix.Application.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _tokenGenerator;

        public AuthenticationService(IJwtTokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "token");
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            Guid userId = Guid.NewGuid();
            var token = _tokenGenerator.GenerateToken(userId, firstName, lastName);
            return new AuthenticationResult(Guid.NewGuid(), firstName, lastName, email, token);

        }
    }
}
