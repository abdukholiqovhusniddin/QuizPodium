using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(u => u.Email).IsRequired();
        builder.Property(u => u.Username).IsRequired();
        builder.Property(u => u.Role).IsRequired();

        builder.HasData(
            new User
            {
                Username = "admin",
                Email = "abdukholiqovh@gmail.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                Role = UserRole.Admin
            });
    }
}
