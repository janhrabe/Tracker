namespace ActivityTracker.UseCases.Projects;

public class ProjectDTO(Guid id, string name, List<Guid> users)
{
  public Guid Id { get; } = id;
  public string Name { get; } = name;
  public List<Guid> Users { get; } = users;
}
