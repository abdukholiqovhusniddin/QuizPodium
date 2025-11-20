using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DataContext;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
