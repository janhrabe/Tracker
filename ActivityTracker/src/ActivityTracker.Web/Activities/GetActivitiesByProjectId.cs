using ActivityTracker.UseCases.Activities;
using ActivityTracker.UseCases.Activities.GetActivityByProject;

namespace ActivityTracker.Web.Activities;

public class GetActivitiesByProjectId(IMediator _mediator)
  : Endpoint<GetActivitiesByProjectIdRequest, List<ActivityByProjectIdDTO>>
{
  public override void Configure()
  {
    Get(GetActivitiesByProjectIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetActivitiesByProjectIdRequest request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new GetActivityByProjectQuery(request.ProjectId), cancellationToken);

    if (result == null || !result.IsSuccess || result.Value == null)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    Response = result.Value;

  }


}
