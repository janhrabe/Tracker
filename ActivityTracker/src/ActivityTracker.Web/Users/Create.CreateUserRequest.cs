using System.ComponentModel.DataAnnotations;

namespace ActivityTracker.Web.Users;
public class CreateUserRequest
{
  public const string Route = "/Users";

  [Required]
  public string? FullName { get; set; }
  public string? ProfilePhotoUrl { get; set; }
}
