using ErrorOr;

namespace Qubix.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Auth
        {
            public static Error InvalidCredentials => Error.Conflict(
                code: "Auth.InvalidCredentials",
                description: "Invalid Credentials");
        }
    }
}
