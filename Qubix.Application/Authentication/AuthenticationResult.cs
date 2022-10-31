using Qubix.Domain.Entities;

namespace Qubix.Application.Authentication
{
    public record AuthenticationResult(User user, string token);
}

