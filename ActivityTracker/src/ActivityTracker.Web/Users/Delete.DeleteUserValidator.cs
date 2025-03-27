namespace ActivityTracker.Web.Users;
/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class DeleteUserValidator : Validator<DeleteUserRequest>
{
  public DeleteUserValidator()
  {
    RuleFor(x => x.UserId);

  }
}
