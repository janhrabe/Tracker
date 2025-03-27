namespace ActivityTracker.Web.Projects;

public class CreateProjectResponse(Guid id, string name, List<Guid> users)
{
  public Guid Id { get; set; } = id;
  public string Name { get; set; } = name;
  public List<Guid> users { get; set; } = users;
}
