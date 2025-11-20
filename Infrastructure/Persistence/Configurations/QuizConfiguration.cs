using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.HasKey(q => q.Id);
        builder.Property(q => q.Title).IsRequired();
        builder.Property(q => q.CreatedAt).HasDefaultValueSql("NOW()");

        builder.HasOne(q => q.CreatedBy)
              .WithMany(u => u.Quizzes)
              .HasForeignKey(q => q.CreatedById)
              .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(q => q.Questions)
              .WithOne(qs => qs.Quiz)
              .HasForeignKey(qs => qs.QuizId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}
