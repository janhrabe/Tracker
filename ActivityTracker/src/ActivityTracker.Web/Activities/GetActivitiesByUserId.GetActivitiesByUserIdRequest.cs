namespace ActivityTracker.Web.Activities;

public class GetActivitiesByUserRequest(Guid userId)
{
  public const string Route = "/Activities/{userId:Guid}";

  public Guid UserId { get; set; } = userId;
}
