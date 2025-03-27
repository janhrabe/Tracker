using ActivityTracker.Core.Entities;

namespace ActivityTracker.UseCases.Users.Update;
public class UpdateUserHandler(IRepository<User> _repository)
  : ICommandHandler<UpdateUserCommand, Result<UserDTO>>
{
  public async Task<Result<UserDTO>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
  {
    var existingUser = await _repository.GetByIdAsync(request.UserId, cancellationToken);
    if (existingUser == null)
    {
      return Result.NotFound();
    }

    existingUser.UpdateUser(request.NewName!);

    await _repository.UpdateAsync(existingUser, cancellationToken);

    return new UserDTO(existingUser.Id,
      existingUser.FullName, existingUser.ProfilePhotoUrl ?? "");
  }
}
