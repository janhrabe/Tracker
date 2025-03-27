using ActivityTracker.Core.Entities;

namespace ActivityTracker.Core.Specifications.UserSpec;
public class UsersByProjectIdSpec : Specification<User>
{
  public UsersByProjectIdSpec(Guid projectId)
  {
    Query.Where(u => (u.Projects ?? new List<Project>()).Any(p => p.Id == projectId));
  }
}
