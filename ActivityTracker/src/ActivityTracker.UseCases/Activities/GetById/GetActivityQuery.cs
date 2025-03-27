namespace ActivityTracker.UseCases.Activities.GetById;
public record GetActivityQuery(Guid ActivityId) : IQuery<Result<ActivityDTO>>;
