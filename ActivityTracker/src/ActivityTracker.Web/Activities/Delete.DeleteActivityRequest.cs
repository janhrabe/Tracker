namespace ActivityTracker.Web.Activities;

public class DeleteActivityRequest
{
  public const string Route = "/Activities/{ActivityId:Guid}";
  public static string BuildRoute(Guid activityId) => Route.Replace("{UserId:Guid}", activityId.ToString());

  public Guid ActivityId { get; set; }
}
