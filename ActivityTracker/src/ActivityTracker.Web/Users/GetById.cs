using ActivityTracker.UseCases.Users.GetById;

namespace ActivityTracker.Web.Users;
/// <summary>
/// Get a User by integer ID.
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching User record.
/// </remarks>
public class GetById(IMediator _mediator)
  : Endpoint<GetUserByIdRequest, UserRecord>
{
  public override void Configure()
  {
    Get(GetUserByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetUserByIdRequest request,
    CancellationToken cancellationToken)
  {
    var query = new GetUserQuery(request.UserId);

    var result = await _mediator.Send(query, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new UserRecord(result.Value.UserId, result.Value.FullName, result.Value.ProfilePhotoUrl);
    }
  }
}
