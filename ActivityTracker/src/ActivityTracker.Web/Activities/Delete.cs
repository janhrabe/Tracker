using ActivityTracker.UseCases.Activities.Delete;
using ActivityTracker.UseCases.Users.Delete;
using ActivityTracker.Web.Users;

namespace ActivityTracker.Web.Activities;


public class Delete(IMediator _mediator)
: Endpoint<DeleteActivityRequest>
{
  public override void Configure()
  {
    Delete(DeleteActivityRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    DeleteActivityRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeleteActivityCommand(request.ActivityId);

    var result = await _mediator.Send(command, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    };
    // TODO: Handle other issues as needed

  }
}
