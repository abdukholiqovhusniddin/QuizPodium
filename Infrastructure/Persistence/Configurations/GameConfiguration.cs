using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.GameCode).IsRequired();
        builder.Property(g => g.IsActive).HasDefaultValue(false);

        builder.HasOne(g => g.Quiz)
              .WithMany(q => q.Games)
              .HasForeignKey(g => g.QuizId)
              .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(g => g.Teacher)
              .WithMany(u => u.Games)
              .HasForeignKey(g => g.TeacherId)
              .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(g => g.Participants)
              .WithOne(p => p.Game)
              .HasForeignKey(p => p.GameId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}
