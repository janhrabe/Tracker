using ActivityTracker.Core.Entities;

namespace ActivityTracker.UseCases.Activities.Update;
public class UpdateActvityHandler(IRepository<Activity> _repository)
  : ICommandHandler<UpdateActivityCommand, Result<ActivityDTO>>
{
  public async Task<Result<ActivityDTO>> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
  {
    var existingActivity = await _repository.GetByIdAsync(request.ActivityId, cancellationToken);
    if (existingActivity == null)
    {
      return Result.NotFound();
    }

    existingActivity.UpdateActivity(request.NewEndDate, request.NewCategory, request.NewDescription);


    await _repository.UpdateAsync(existingActivity, cancellationToken);

    return new ActivityDTO(existingActivity.Id, existingActivity.ProjectId, existingActivity.UserId, existingActivity.StartDate,
      existingActivity.EndDate, existingActivity.Category, existingActivity.Description ?? "");
  }
}
