namespace Qubix.Application.Authentication
{
    public record AuthenticationResult(Guid id, string firstName, string lastName, string email, string token);
}

