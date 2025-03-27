namespace ActivityTracker.UseCases.Activities.GetActivityByProject;
public record GetActivityByProjectQuery(Guid ProjectId) : IQuery<Result<List<ActivityByProjectIdDTO>>>;

