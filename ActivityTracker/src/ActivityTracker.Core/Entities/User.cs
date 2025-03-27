namespace ActivityTracker.Core.Entities;
public class User : BaseEntity
{
  public new Guid Id { get; set; }
  public required string FullName { get; set; }

  public required string ProfilePhotoUrl { get; set; }

  public ICollection<Activity>? Activities { get; set; }

  public ICollection<Project>? Projects { get; set; }


  public User()
  { }

  public User(string fullName, string profilePhotoUrl)
  {
    FullName = fullName;
    ProfilePhotoUrl = profilePhotoUrl;
  }


  public void UpdateUser(string newName) => FullName = Guard.Against.NullOrEmpty(newName, nameof(newName));
}
