using ActivityTracker.Core.Entities;
using ActivityTracker.Core.Interfaces;
using ActivityTracker.Infrastructure.Data;

namespace ActivityTracker.Infrastructure.Repositories;
public class UserRepository : EfRepository<User>, IUserRepository
{
  public UserRepository(AppDbContext dbContext) : base(dbContext)
  {
  }
}
