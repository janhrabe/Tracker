//using ActivityTracker.Core.Entities;

//namespace ActivityTracker.IntegrationTests.Data;
//public class EfRepositoryDelete : BaseEfRepoTestFixture
//{
//  [Fact]
//  public async Task DeletesItemAfterAddingIt()
//  {
//    // add a user
//    var repository = GetRepository();
//    var initialName = Guid.NewGuid().ToString();
//    var user = new User(initialName);
//    await repository.AddAsync(user);

//    // delete the item
//    await repository.DeleteAsync(user);

//    // verify it's no longer there
//    Assert.DoesNotContain(await repository.ListAsync(),
//        User => User.FullName == initialName);
//  }
//}
