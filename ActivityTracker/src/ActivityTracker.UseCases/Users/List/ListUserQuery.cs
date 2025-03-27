using ActivityTracker.UseCases.Users;

namespace ActivityTracker.UseCases.Contributors.List;

public record ListUserQuery(int? Skip, int? Take) : IQuery<Result<List<UserDTO>>>;
