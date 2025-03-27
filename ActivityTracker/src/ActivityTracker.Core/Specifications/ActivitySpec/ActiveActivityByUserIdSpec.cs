using ActivityTracker.Core.Entities;

namespace ActivityTracker.Core.Specifications.ActivitySpec;
public class ActiveActivityByUserIdSpec : Specification<Activity>
{
  public ActiveActivityByUserIdSpec(Guid userId)
  {
    Query.Where(a => a.UserId == userId && a.EndDate == null);
  }
}
