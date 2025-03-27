using ActivityTracker.UseCases.Activities;
using ActivityTracker.UseCases.Activities.GetActivityByUser;

namespace ActivityTracker.Web.Activities;

public class GetActivitiesByUserId(IMediator _mediator)
  : Endpoint<GetActivitiesByUserRequest, List<ActivityByUserIdDTO>>
{
  public override void Configure()
  {
    Get(GetActivitiesByUserRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetActivitiesByUserRequest request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new GetActivityByUserQuery(request.UserId), cancellationToken);

    if (result == null || !result.IsSuccess || result.Value == null)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    Response = result.Value;

  }

}
