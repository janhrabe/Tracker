namespace ActivityTracker.Web.Users;

public record DeleteUserRequest
{
  public const string Route = "/Users/{UserId:Guid}";
  public static string BuildRoute(Guid userId) => Route.Replace("{UserId:Guid}", userId.ToString());

  public Guid UserId { get; set; }
}
