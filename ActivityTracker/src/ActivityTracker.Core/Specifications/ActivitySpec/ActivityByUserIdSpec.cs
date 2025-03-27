using ActivityTracker.Core.Entities;

namespace ActivityTracker.Core.Specifications.ActivitySpec;
public class ActivityByUserIdSpec : Specification<Activity>
{
  public ActivityByUserIdSpec(Guid userId)
  {
    Query.Where(a => a.UserId == userId)
         .OrderBy(a => a.ProjectId);
  }

}
