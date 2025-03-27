using ActivityTracker.Core.Entities;
using ActivityTracker.Core.Interfaces;
using ActivityTracker.Infrastructure.Data;

namespace ActivityTracker.Infrastructure.Repositories;
public class ProjectRepository : EfRepository<Project>, IProjectRepository
{
  public ProjectRepository(AppDbContext dbContext) : base(dbContext)
  {
  }
}
