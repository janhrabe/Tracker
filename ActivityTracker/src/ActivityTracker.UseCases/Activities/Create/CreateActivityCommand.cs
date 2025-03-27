namespace ActivityTracker.UseCases.Activities.Create;
public record CreateActivityCommand(DateTime StartDate, string Category, string Description, Guid UserId, Guid ProjectId) : Ardalis.SharedKernel.ICommand<Result<ActivityByUserIdDTO>>;

