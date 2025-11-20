using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
{
    public void Configure(EntityTypeBuilder<Participant> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Username).IsRequired();
        builder.Property(p => p.JoinedAt).HasDefaultValueSql("NOW()");

        builder.HasMany(p => p.Answers)
              .WithOne(a => a.Participant)
              .HasForeignKey(a => a.ParticipantId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}
