namespace ActivityTracker.Web.Users;

public class GetUserByIdRequest
{
  public const string Route = "/Users/{UserId:Guid}";

  public Guid UserId { get; set; }

  public static string BuildRoute(Guid userId) => Route.Replace("{UserId:Guid}", userId.ToString());
}
