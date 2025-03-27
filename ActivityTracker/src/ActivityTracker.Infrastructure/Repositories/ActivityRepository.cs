using ActivityTracker.Core.Entities;
using ActivityTracker.Core.Interfaces;
using ActivityTracker.Infrastructure.Data;

namespace ActivityTracker.Infrastructure.Repositories;
public class ActivityRepository : EfRepository<Activity>, IActivityRepository
{
  public ActivityRepository(AppDbContext dbContext) : base(dbContext)
  {
  }
}
