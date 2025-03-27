namespace ActivityTracker.UseCases.Activities.Delete;

public record DeleteActivityCommand(Guid ActivityId) : ICommand<Result>;
