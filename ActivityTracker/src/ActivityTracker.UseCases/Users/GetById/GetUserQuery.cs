namespace ActivityTracker.UseCases.Users.GetById;

public record GetUserQuery(Guid UserId) : IQuery<Result<UserDTO>>;
