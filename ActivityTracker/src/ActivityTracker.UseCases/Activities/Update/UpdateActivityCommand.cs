namespace ActivityTracker.UseCases.Activities.Update;
public record UpdateActivityCommand(Guid ActivityId, DateTime? NewEndDate, string NewCategory, string NewDescription) : ICommand<Result<ActivityDTO>>;

