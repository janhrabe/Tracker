using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityTracker.Core.Entities;
public class Activity : BaseEntity
{
  public new Guid Id { get; set; }
  public required DateTime StartDate { get; set; } = new DateTime();

  public DateTime? EndDate { get; set; }

  public required string Category { get; set; }

  public required string Description { get; set; }

  public ActivityStatus Status => EndDate.HasValue ? ActivityStatus.Closed : ActivityStatus.Active;

  [ForeignKey(nameof(User))]
  public required Guid UserId { get; set; }
  public User? User { get; set; }

  [ForeignKey(nameof(Project))]
  public required Guid ProjectId { get; set; }
  public Project? Project { get; set; }

  public Activity()
  { }

  public Activity(DateTime startDate, string category, string description, Guid userId, Guid projectId)
  {
    StartDate = startDate;
    Category = category;
    Description = description;
    UserId = userId;
    ProjectId = projectId;
  }

  public void UpdateActivity(DateTime? newEndDate, string newCategory, string newDescription)
  {

    Category = Guard.Against.NullOrEmpty(newCategory, nameof(newCategory));
    Description = Guard.Against.NullOrEmpty(newDescription, nameof(newDescription));
    EndDate = newEndDate.HasValue && newEndDate.Value >= DateTime.Now ? newEndDate.Value : throw new ArgumentOutOfRangeException(nameof(newEndDate), "EndDate cannot be in the past.");
  }
}
