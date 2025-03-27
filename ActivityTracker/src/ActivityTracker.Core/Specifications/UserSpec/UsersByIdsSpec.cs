using ActivityTracker.Core.Entities;

namespace ActivityTracker.Core.Specifications.UserSpec;
public class UsersByIdsSpec : Specification<User>
{
  public UsersByIdsSpec(IEnumerable<Guid> userIds)
  {
    Query.Where(u => userIds.Contains(u.Id));
  }
}
