namespace ActivityTracker.UseCases.Users.Create;

/// <summary>
/// Create a new Contributor.
/// </summary>
/// <param name="Name"></param>
public record CreateUserCommand(string FullName, string ProfilePhotoUrl) : ICommand<Result<Guid>>;
