using ActivityTracker.Core.Entities;
using ActivityTracker.Core.Specifications.UserSpec;

namespace ActivityTracker.UseCases.Projects;
public class CreateProjectHandler(IRepository<Project> _repository, IRepository<User> _userRepository)
  : ICommandHandler<CreateProjectCommand, Result<ProjectDTO>>

{
  public async Task<Result<ProjectDTO>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
  {

    if (request.UserIds == null || request.UserIds.Count == 0)
    {
      return Result.Invalid();
    }


    var spec = new UsersByIdsSpec(request.UserIds);
    var users = await _userRepository.ListAsync(spec, cancellationToken);

    if (users.Count != request.UserIds.Count)
    {
      return Result.Invalid();
    }

    var project = new Project
    {
      Name = request.Name,
      Users = users
    };


    await _repository.AddAsync(project, cancellationToken);
    await _repository.SaveChangesAsync(cancellationToken);


    var projectDTO = new ProjectDTO(project.Id, project.Name, users.Select(u => u.Id).ToList());

    return Result.Success(projectDTO);
  }
}
