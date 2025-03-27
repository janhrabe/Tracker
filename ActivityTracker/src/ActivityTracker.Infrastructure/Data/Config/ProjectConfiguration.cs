using ActivityTracker.Core.Entities;

namespace ActivityTracker.Infrastructure.Data.Config;
internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
  public void Configure(EntityTypeBuilder<Project> builder)
  {
    builder.Property(x => x.Name)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
  }
}
