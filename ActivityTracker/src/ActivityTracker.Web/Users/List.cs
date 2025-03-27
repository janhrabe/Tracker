using ActivityTracker.UseCases.Contributors.List;

namespace ActivityTracker.Web.Users;
/// <summary>
/// List all Contributors
/// </summary>
/// <remarks>
/// List all contributors - returns a UserListResponse containing the Contributors.
/// </remarks>
public class List(IMediator _mediator) : EndpointWithoutRequest<UserListResponse>
{
  public override void Configure()
  {
    Get("/Users");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ListUserQuery(null, null), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new UserListResponse
      {
        users = result.Value.Select(c => new UserRecord(c.UserId, c.FullName, c.ProfilePhotoUrl)).ToList()
      };
    }
  }
}
