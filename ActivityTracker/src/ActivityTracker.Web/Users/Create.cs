
using ActivityTracker.UseCases.Users.Create;

namespace ActivityTracker.Web.Users;

public class Create(IMediator _mediator)
  : Endpoint<CreateUserRequest, CreateUserResponse>
{
  public override void Configure()
  {
    Post(CreateUserRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {

      s.ExampleRequest = new CreateUserRequest { FullName = "User Name", ProfilePhotoUrl = "path.jpeg" };
    });
  }

  public override async Task HandleAsync(
    CreateUserRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateUserCommand(request.FullName!,
      request.ProfilePhotoUrl!), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CreateUserResponse(result.Value, request.FullName!);
      return;
    }

  }
}
