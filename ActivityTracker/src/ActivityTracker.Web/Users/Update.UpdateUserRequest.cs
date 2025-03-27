using System.ComponentModel.DataAnnotations;

namespace ActivityTracker.Web.Users;
public class UpdateUserRequest
{
  public const string Route = "/Users/{UserId:Guid}";
  public static string BuildRoute(Guid userId) => Route.Replace("{UserId:Guid}", userId.ToString());


  [Required]
  public Guid UserId { get; set; }
  [Required]
  public string? FullName { get; set; }
  [Required]
  public string? ProfilePhotoUrl { get; set; }
}
