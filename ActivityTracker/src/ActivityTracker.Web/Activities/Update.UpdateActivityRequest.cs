using System.ComponentModel.DataAnnotations;

namespace ActivityTracker.Web.Activities;

public class UpdateActivityRequest
{
  public const string Route = "/Activities/{ActivityId:Guid}";
  public static string BuildRoute(Guid activityId) => Route.Replace("{ActivityId:Guid}", activityId.ToString());


  [Required]
  public Guid ActivityId { get; set; }

  public DateTime? EndDate { get; set; }
  [Required]
  public string? Category { get; set; }

  [Required]
  public string? Description { get; set; }
}
