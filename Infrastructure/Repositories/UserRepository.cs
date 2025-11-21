using Domain.Interfaces;
using Infrastructure.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class UserRepository(AppDbContext context) : IUserRepository
{
    private readonly AppDbContext _context = context;
    public async Task CreateAsync(User user, CancellationToken cancellationToken) =>
        await _context.Users.AddAsync(user, cancellationToken);

    public async Task<bool> ExistsAsync(string usernameOrEmail) =>
        await _context.Users.AnyAsync(u => (u.Username == usernameOrEmail
        || u.Email == usernameOrEmail) && u.IsActive);

    public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken) =>
        await _context.Users.AsNoTracking()
            .FirstOrDefaultAsync(u => u.Username == username && u.IsActive, cancellationToken);
}
