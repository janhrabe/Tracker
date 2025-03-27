namespace ActivityTracker.Core.Entities;
public class Project : BaseEntity
{
  public new Guid Id { get; set; }
  public required string Name { get; set; }

  public required ICollection<User> Users { get; set; }

  public ICollection<Activity>? Activities { get; set; }


  public Project()
  { }

  public Project(string name, ICollection<User> users)
  {
    Name = name;
    Users = users;
  }
}
