namespace ActivityTracker.UseCases.Users.Update;

public record UpdateUserCommand(Guid UserId, string NewName, string NewProfilePictureUrl) : ICommand<Result<UserDTO>>;
