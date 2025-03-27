using ActivityTracker.UseCases.Activities.Create;

namespace ActivityTracker.Web.Activities;

public class Create(IMediator _mediator)
  : Endpoint<CreateActivityRequest, CreateActivityResponse>
{
  public override void Configure()
  {
    Post(CreateActivityRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {

      s.ExampleRequest = new CreateActivityRequest { Category = "Category", Description = "Description" };
    });
  }

  public override async Task HandleAsync(
    CreateActivityRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateActivityCommand(request.StartDate, request.Category, request.Description, request.UserId, request.ProjectId), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CreateActivityResponse(request.StartDate, request.Category, request.Description, request.UserId, request.ProjectId);
      return;
    }

  }
}
