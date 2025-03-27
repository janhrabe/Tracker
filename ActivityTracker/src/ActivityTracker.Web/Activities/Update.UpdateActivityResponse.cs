namespace ActivityTracker.Web.Activities;

public class UpdateActivityResponse(ActivityRecord activity)
{
  public ActivityRecord activity { get; set; } = activity;
}
