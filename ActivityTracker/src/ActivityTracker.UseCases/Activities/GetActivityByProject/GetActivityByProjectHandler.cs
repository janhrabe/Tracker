using ActivityTracker.Core.Entities;
using ActivityTracker.Core.Specifications.ActivitySpec;

namespace ActivityTracker.UseCases.Activities.GetActivityByProject;
public class GetActivityByProjectHandler(IReadRepository<Activity> _repository)
  : IQueryHandler<GetActivityByProjectQuery, Result<List<ActivityByProjectIdDTO>>>
{
  public async Task<Result<List<ActivityByProjectIdDTO>>> Handle(GetActivityByProjectQuery request, CancellationToken cancellationToken)
  {
    var spec = new ActivityByUserIdSpec(request.ProjectId);
    var entities = await _repository.ListAsync(spec, cancellationToken);
    if (entities == null || entities.Count == 0)
      return Result.NotFound();

    var activityDTOs = entities.Select(a =>
    new ActivityByProjectIdDTO(a.Id, a.UserId, a.StartDate, a.EndDate, a.Category, a.Description)).ToList();
    return Result.Success(activityDTOs);
  }
}
