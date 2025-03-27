using ActivityTracker.UseCases.Users.GetById;
using ActivityTracker.UseCases.Users.Update;

namespace ActivityTracker.Web.Users;
/// <summary>
/// Update an existing User.
/// </summary>
/// <remarks>
/// Update an existing User by providing a fully defined replacement set of values.
/// See: https://stackoverflow.com/questions/60761955/rest-update-best-practice-put-collection-id-without-id-in-body-vs-put-collecti
/// </remarks>
public class Update(IMediator _mediator)
  : Endpoint<UpdateUserRequest, UpdateUserResponse>
{
  public override void Configure()
  {
    Put(UpdateUserRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdateUserRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateUserCommand(request.UserId, request.FullName!, request.ProfilePhotoUrl!), cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetUserQuery(request.UserId);

    var queryResult = await _mediator.Send(query, cancellationToken);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdateUserResponse(new UserRecord(dto.UserId, dto.FullName, dto.ProfilePhotoUrl));
      return;
    }
  }
}
