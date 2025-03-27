namespace ActivityTracker.Web.Activities;

public class GetActivitiesByProjectIdRequest(Guid projectId)
{
  public const string Route = "/Activities/{projectId:Guid}";

  public Guid ProjectId { get; set; } = projectId;
}
