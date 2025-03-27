using ActivityTracker.Core.Entities;
using ActivityTracker.Infrastructure.Data;
using ActivityTracker.Infrastructure.Repositories;


namespace ActivityTracker.Infrastructure;
public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger)
  {
    string? connectionString = config.GetConnectionString("ActivityConnection");
    Guard.Against.Null(connectionString);

    services.AddDbContext<AppDbContext>(options =>
      options.UseSqlServer(connectionString));


    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
            .AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>))
            .AddScoped(typeof(IRepository<Activity>), typeof(ActivityRepository))
            .AddScoped(typeof(IReadRepository<Activity>), typeof(ActivityRepository))
            .AddScoped(typeof(IRepository<User>), typeof(UserRepository))
            .AddScoped(typeof(IReadRepository<User>), typeof(UserRepository));




    logger.LogInformation("{Project} services registered", "Infrastructure");

    return services;
  }
}
