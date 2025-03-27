using ActivityTracker.Core.Entities;

namespace ActivityTracker.Infrastructure.Data.Config;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.Property(p => p.FullName)
        .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);





  }
}
