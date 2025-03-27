using ActivityTracker.Core.Entities;
using MediatR;

namespace ActivityTracker.UseCases.Users.Delete;

public class DeleteUserHandler(IRepository<User> _repository)
  : IRequestHandler<DeleteUserCommand, Result>
{
  public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
  {
    var user = await _repository.GetByIdAsync(request.UserId, cancellationToken);

    if (user == null)
    {
      return Result.NotFound($"User with Id {request.UserId} not found");
    }

    await _repository.DeleteAsync(user, cancellationToken);
    await _repository.SaveChangesAsync(cancellationToken);

    return Result.Success();
  }
}
