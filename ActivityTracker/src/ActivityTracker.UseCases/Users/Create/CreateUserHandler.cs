using ActivityTracker.Core.Entities;

namespace ActivityTracker.UseCases.Users.Create;
public class CreateUserHandler(IRepository<User> _repository)
  : ICommandHandler<CreateUserCommand, Result<Guid>>
{
  public async Task<Result<Guid>> Handle(CreateUserCommand request,
    CancellationToken cancellationToken)
  {
    var newUser = new User(request.FullName, request.ProfilePhotoUrl)
    {
      FullName = request.FullName,
      ProfilePhotoUrl = request.ProfilePhotoUrl
    };


    if (!string.IsNullOrEmpty(request.FullName))
    {

    }
    var createdUser = await _repository.AddAsync(newUser, cancellationToken);

    return createdUser.Id;
  }
}
