namespace ActivityTracker.Web.Users;

public class CreateUserResponse(Guid id, string fullName)
{
  public Guid UserId { get; set; } = id;
  public string FullName { get; set; } = fullName;
}
