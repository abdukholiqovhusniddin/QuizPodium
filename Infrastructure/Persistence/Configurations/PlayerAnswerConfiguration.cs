using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public class PlayerAnswerConfiguration : IEntityTypeConfiguration<PlayerAnswer>
{
    public void Configure(EntityTypeBuilder<PlayerAnswer> builder)
    {
        builder.HasKey(pa => pa.Id);
        builder.Property(pa => pa.PointsEarned).HasDefaultValue(0);
        builder.Property(pa => pa.AnsweredAt).HasDefaultValueSql("NOW()");

        builder.HasOne(pa => pa.Question)
              .WithMany()
              .HasForeignKey(pa => pa.QuestionId)
              .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pa => pa.SelectedOption)
              .WithMany()
              .HasForeignKey(pa => pa.SelectedOptionId)
              .OnDelete(DeleteBehavior.Restrict);
    }
}
