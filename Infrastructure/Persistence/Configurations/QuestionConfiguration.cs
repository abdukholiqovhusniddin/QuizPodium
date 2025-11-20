using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(q => q.Id);
        builder.Property(q => q.Text).IsRequired();
        builder.Property(q => q.TimeLimitSeconds).HasDefaultValue(20);
        builder.Property(q => q.Points).HasDefaultValue(100);

        builder.HasMany(q => q.Options)
              .WithOne(o => o.Question)
              .HasForeignKey(o => o.QuestionId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}
