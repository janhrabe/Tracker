namespace ActivityTracker.Web.Activities;

public class CreateActivityResponse(DateTime startdate, string category, string description, Guid userId, Guid projectId)
{
  public DateTime Startdate { get; set; } = startdate;
  public string Category { get; set; } = category;

  public string Description { get; set; } = description;
  public Guid UserId { get; set; } = userId;
  public Guid ProjectId { get; set; } = projectId;
}
