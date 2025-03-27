using ActivityTracker.Core.Entities;

namespace ActivityTracker.Infrastructure.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

  public DbSet<User> Users => Set<User>();
  public DbSet<Activity> Activities => Set<Activity>();
  public DbSet<Project> Projects => Set<Project>();
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    modelBuilder.Entity<Activity>().Property<DateTime>(nameof(Activity.StartDate)).HasDefaultValue(new DateTime(2025, 01, 01));

    modelBuilder.Entity<User>()
      .HasMany(u => u.Projects)
      .WithMany(p => p.Users);

    modelBuilder.Entity<Project>()
      .HasMany(p => p.Activities)
      .WithOne(a => a.Project)
      .HasForeignKey(a => a.ProjectId);

    modelBuilder.Entity<User>()
      .HasMany(u => u.Activities)
      .WithOne(a => a.User)
      .HasForeignKey(a => a.UserId);


  }
}
