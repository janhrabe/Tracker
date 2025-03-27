namespace ActivityTracker.Infrastructure.Data;

public static class AppDbContextExtensions
{

  public static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("ActivityConnection");
    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));
  }



}
