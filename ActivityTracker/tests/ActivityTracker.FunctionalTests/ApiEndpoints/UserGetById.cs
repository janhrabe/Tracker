//using ActivityTracker.Web.Contributors;

//namespace ActivityTracker.FunctionalTests.ApiEndpoints;
//[Collection("Sequential")]
//public class UserGetById(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
//{
//  private readonly HttpClient _client = factory.CreateClient();

//  [Fact]
//  public async Task ReturnsSeedContributorGivenId1()
//  {
//    var result = await _client.GetAndDeserializeAsync<UserRecord>(GetUserByIdRequest.BuildRoute(1));

//    Assert.Equal(1, result.Id);

//  }

//  [Fact]
//  public async Task ReturnsNotFoundGivenId1000()
//  {
//    string route = GetUserByIdRequest.BuildRoute(1000);
//    _ = await _client.GetAndEnsureNotFoundAsync(route);
//  }
//}
