using Qubix.Domain.Entities;

namespace Qubix.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        void Add(User user);

        User? GetUserByEmail(string email);
    }
}
