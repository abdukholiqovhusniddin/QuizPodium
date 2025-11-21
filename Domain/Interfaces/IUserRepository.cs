

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task CreateAsync(User user, CancellationToken cancellationToken);
    Task<bool> ExistsAsync(string usernameOrEmail);
    Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
}
