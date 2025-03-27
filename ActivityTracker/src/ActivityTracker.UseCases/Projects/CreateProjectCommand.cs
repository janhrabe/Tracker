namespace ActivityTracker.UseCases.Projects;
public record CreateProjectCommand(string Name, List<Guid> UserIds) : Ardalis.SharedKernel.ICommand<Result<ProjectDTO>>;

