namespace ActivityTracker.Web.Activities;

public class CreateActivityRequest
{
  public const string Route = "/Activities";


  public DateTime StartDate { get; set; }

  public required string Category { get; set; }

  public required string Description { get; set; }

  public Guid UserId { get; set; }

  public Guid ProjectId { get; set; }

}
