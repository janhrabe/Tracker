using ActivityTracker.Core.Entities;

namespace ActivityTracker.Core.Specifications.ActivitySpec;
public class ActivityByIdSpec : Specification<Activity>
{
  public ActivityByIdSpec(Guid activityId
    )
  {
    Query.Where(a => a.Id == activityId);
  }
}
