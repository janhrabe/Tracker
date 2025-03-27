using ActivityTracker.UseCases.Activities.GetById;
using ActivityTracker.UseCases.Activities.Update;

namespace ActivityTracker.Web.Activities;


public class Update(IMediator _mediator)
  : Endpoint<UpdateActivityRequest, UpdateActivityResponse>
{
  public override void Configure()
  {
    Put(UpdateActivityRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdateActivityRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateActivityCommand(request.ActivityId, request.EndDate, request.Category!, request.Description!), cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetActivityQuery(request.ActivityId);

    var queryResult = await _mediator.Send(query, cancellationToken);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdateActivityResponse(new ActivityRecord(dto.activtiyId, dto.projectId, dto.userId, dto.startDate, dto.endDate, dto.category, dto.description));
      return;
    }
  }
}

