namespace ActivityTracker.UseCases.Users.Delete;

public record DeleteUserCommand(Guid UserId) : ICommand<Result>;
