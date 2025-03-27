using ActivityTracker.Core.Entities;

namespace ActivityTracker.IntegrationTests.Data;
public class EfRepositoryAdd : BaseEfRepoTestFixture
{
  [Fact]
  public async Task AddsContributorAndSetsId()
  {
    var testUserName = "testContributor";
    var testProfilePhotoUrl = "path.jpeg";

    var repository = GetRepository();
    var user = new User { FullName = testUserName, ProfilePhotoUrl = testProfilePhotoUrl };

    await repository.AddAsync(user);

    var newUser = (await repository.ListAsync())
                    .FirstOrDefault();

    Assert.Equal(testUserName, newUser?.FullName);

  }
}
