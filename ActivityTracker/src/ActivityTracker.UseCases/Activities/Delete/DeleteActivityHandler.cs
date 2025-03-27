using ActivityTracker.Core.Entities;
using MediatR;

namespace ActivityTracker.UseCases.Activities.Delete;
public class DeleteActivityHandler(IRepository<Activity> _repository)
  : IRequestHandler<DeleteActivityCommand, Result>
{
  public async Task<Result> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
  {
    var activity = await _repository.GetByIdAsync(request.ActivityId, cancellationToken);

    if (activity == null)
    {
      return Result.NotFound($"Activity with Id {request.ActivityId} not found");
    }

    await _repository.DeleteAsync(activity, cancellationToken);
    await _repository.SaveChangesAsync(cancellationToken);

    return Result.Success();
  }
}

