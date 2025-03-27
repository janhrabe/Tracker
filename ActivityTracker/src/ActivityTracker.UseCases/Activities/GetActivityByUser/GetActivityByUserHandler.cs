using ActivityTracker.Core.Entities;
using ActivityTracker.Core.Specifications.ActivitySpec;

namespace ActivityTracker.UseCases.Activities.GetActivityByUser;
public class GetActivityByUserHandler(IReadRepository<Activity> _repository)
  : IQueryHandler<GetActivityByUserQuery, Result<List<ActivityByUserIdDTO>>>
{
  public async Task<Result<List<ActivityByUserIdDTO>>> Handle(GetActivityByUserQuery request, CancellationToken cancellationToken)
  {
    var spec = new ActivityByUserIdSpec(request.UserId);
    var entities = await _repository.ListAsync(spec, cancellationToken);
    if (entities == null || entities.Count == 0)
      return Result.NotFound();

    var activityDTOs = entities.Select(a =>
    new ActivityByUserIdDTO(a.Id, a.ProjectId, a.StartDate, a.EndDate, a.Category, a.Description)).ToList();
    return Result.Success(activityDTOs);
  }
}
