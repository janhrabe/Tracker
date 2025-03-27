﻿using ActivityTracker.Infrastructure;

namespace ActivityTracker.Web.Configurations;
public static class ServiceConfigs
{
  public static IServiceCollection AddServiceConfigs(this IServiceCollection services, Microsoft.Extensions.Logging.ILogger logger, WebApplicationBuilder builder)
  {
    services.AddInfrastructureServices(builder.Configuration, logger)
            .AddMediatrConfigs();



    logger.LogInformation("{Project} services registered", "Mediatr and Email Sender");

    return services;
  }


}
