using Qubix.Application.Common.Interfaces.Authentication;
using Qubix.Application.Common.Interfaces.Persistence;
using Qubix.Domain.Entities;

namespace Qubix.Application.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository)
        {
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Login(string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User does not exists");
            }

            if (user.Password != password)
            {
                throw new Exception("Password incorrect");
            }
            var token = _tokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User already exists");
            }
            var user = new User
            {
                Name = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            _userRepository.Add(user);

            var token = _tokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);

        }
    }
}
