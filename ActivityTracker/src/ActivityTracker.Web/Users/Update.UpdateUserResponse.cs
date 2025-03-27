namespace ActivityTracker.Web.Users;

public class UpdateUserResponse(UserRecord user)
{
  public UserRecord User { get; set; } = user;
}
