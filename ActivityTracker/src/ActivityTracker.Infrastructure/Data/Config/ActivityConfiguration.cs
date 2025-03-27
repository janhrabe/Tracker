using ActivityTracker.Core.Entities;

namespace ActivityTracker.Infrastructure.Data.Config;
public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
  public void Configure(EntityTypeBuilder<Activity> builder)
  {
    builder.Property(x => x.Description)
      .HasMaxLength(100);

    builder.Property(x => x.StartDate)
      .HasDefaultValue(DateTime.UtcNow);

    builder.Property(x => x.UserId)
      .IsRequired();
  }
}
