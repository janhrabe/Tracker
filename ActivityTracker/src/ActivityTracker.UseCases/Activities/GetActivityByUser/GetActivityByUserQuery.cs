namespace ActivityTracker.UseCases.Activities.GetActivityByUser;
public record GetActivityByUserQuery(Guid UserId) : IQuery<Result<List<ActivityByUserIdDTO>>>;

