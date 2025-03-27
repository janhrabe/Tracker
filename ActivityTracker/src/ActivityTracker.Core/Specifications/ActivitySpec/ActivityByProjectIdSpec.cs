using ActivityTracker.Core.Entities;

namespace ActivityTracker.Core.Specifications.ActivitySpec;
public class ActivityByProjectIdSpec : Specification<Activity>
{
  public ActivityByProjectIdSpec(Guid projectId)
  {
    Query.Where(a => a.ProjectId == projectId);
  }
}
