using ActivityTracker.Core.Entities;

namespace ActivityTracker.UseCases.Users.GetById;
/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetUserHandler(IReadRepository<User> _repository)
  : IQueryHandler<GetUserQuery, Result<UserDTO>>
{
  public async Task<Result<UserDTO>> Handle(GetUserQuery request, CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(request.UserId, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new UserDTO(entity.Id, entity.FullName, entity.ProfilePhotoUrl ?? "");
  }
}
