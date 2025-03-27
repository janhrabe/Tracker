using System.ComponentModel.DataAnnotations;

namespace ActivityTracker.Web.Projects;

public class CreateProjectRequest
{
  public const string Route = "/Projects";

  [Required]
  public required string Name { get; set; }
  public required List<Guid> Users { get; set; }
}
