using ActivityTracker.Core.Entities;
using ActivityTracker.UseCases.Users;

namespace ActivityTracker.UseCases.Contributors.List;

public class ListUsersHandler(IReadRepository<User> _repository)
  : IQueryHandler<ListUserQuery, Result<List<UserDTO>>>
{
  public async Task<Result<List<UserDTO>>> Handle(ListUserQuery request, CancellationToken cancellationToken)
  {
    var users = await _repository.ListAsync();

    var UserDTOs = users.Select(u =>
    new UserDTO(u.Id, u.FullName, u.ProfilePhotoUrl)).ToList();


    return Result.Success(UserDTOs);
  }
}
