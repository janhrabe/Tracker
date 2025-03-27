using ActivityTracker.UseCases.Projects;

namespace ActivityTracker.Web.Projects;

public class Create(IMediator mediator)
  : Endpoint<CreateProjectRequest, CreateProjectResponse>
{
  public override void Configure()
  {
    Post(CreateProjectRequest.Route);
    AllowAnonymous();

  }

  public override async Task HandleAsync(
    CreateProjectRequest request,
    CancellationToken cancellationToken)
  {
    var result = await mediator.Send(new CreateProjectCommand(request.Name, request.Users), cancellationToken);

    if (!result.IsSuccess)
    {
      await SendErrorsAsync(400, cancellationToken);
      return;
    }


    Response = new CreateProjectResponse(result.Value.Id, result.Value.Name, result.Value.Users);
  }
}
