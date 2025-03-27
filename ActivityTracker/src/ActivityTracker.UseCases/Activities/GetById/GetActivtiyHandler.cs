using ActivityTracker.Core.Entities;

namespace ActivityTracker.UseCases.Activities.GetById;
public class GetActivityHandler(IReadRepository<Activity> _repository)
  : IQueryHandler<GetActivityQuery, Result<ActivityDTO>>
{
  public async Task<Result<ActivityDTO>> Handle(GetActivityQuery request, CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(request.ActivityId, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new ActivityDTO(entity.Id, entity.ProjectId, entity.UserId, entity.StartDate, entity.EndDate, entity.Category, entity.Description ?? "");
  }
}
