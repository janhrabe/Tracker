using System.Reflection;
using ActivityTracker.Core.Entities;
using ActivityTracker.UseCases.Users.Create;
using Ardalis.SharedKernel;

namespace ActivityTracker.Web.Configurations;
public static class MediatrConfigs
{
  public static IServiceCollection AddMediatrConfigs(this IServiceCollection services)
  {
    var mediatRAssemblies = new[]
      {
        Assembly.GetAssembly(typeof(User)), // Core
        Assembly.GetAssembly(typeof(CreateUserCommand)) // UseCases
      };

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
            .AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();

    return services;
  }
}
