using ActivityTracker.Core.Entities;
using ActivityTracker.Core.Specifications.ActivitySpec;

namespace ActivityTracker.UseCases.Activities.Create;
public class CreateActivityHandler(IRepository<Activity> _repository)
  : ICommandHandler<CreateActivityCommand, Result<ActivityByUserIdDTO>>
{
  public async Task<Result<ActivityByUserIdDTO>> Handle(CreateActivityCommand request,
    CancellationToken cancellationToken)
  {
    var spec = new ActiveActivityByUserIdSpec(request.UserId);
    var activeActivity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);

    if (activeActivity != null)
    {
      activeActivity.EndDate = DateTime.Now;
      await _repository.UpdateAsync(activeActivity, cancellationToken);
    }

    var newActivity = new Activity(request.StartDate, request.Category, request.Description, request.UserId, request.ProjectId)
    {
      StartDate = request.StartDate,
      Category = request.Category,
      Description = request.Description,
      UserId = request.UserId,
      ProjectId = request.ProjectId,
    };


    await _repository.AddAsync(newActivity, cancellationToken);

    return Result.Success();
  }
}

