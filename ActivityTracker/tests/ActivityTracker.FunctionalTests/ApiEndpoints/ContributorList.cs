using ActivityTracker.Web.Users;

namespace ActivityTracker.FunctionalTests.ApiEndpoints;
[Collection("Sequential")]
public class ContributorList(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task ReturnsTwoContributors()
  {
    var result = await _client.GetAndDeserializeAsync<UserListResponse>("/Contributors");

    Assert.Equal(2, result.users.Count);

  }
}
