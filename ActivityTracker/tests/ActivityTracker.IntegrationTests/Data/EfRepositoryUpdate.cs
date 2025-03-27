//using ActivityTracker.Core.Entities;

//namespace ActivityTracker.IntegrationTests.Data;
//public class EfRepositoryUpdate : BaseEfRepoTestFixture
//{
//  [Fact]
//  public async Task UpdatesItemAfterAddingIt()
//  {
//    // add a user
//    var repository = GetRepository();
//    var initialName = Guid.NewGuid().ToString();
//    var user = new User(initialName);

//    await repository.AddAsync(user);

//    // detach the item so we get a different instance
//    _dbContext.Entry(user).State = EntityState.Detached;

//    // fetch the item and update its title
//    var newUser = (await repository.ListAsync())
//        .FirstOrDefault(User => User.FullName == initialName);
//    if (newUser == null)
//    {
//      Assert.NotNull(newUser);
//      return;
//    }
//    Assert.NotSame(user, newUser);
//    var newName = Guid.NewGuid().ToString();
//    newUser.UpdateName(newName);

//    // Update the item
//    await repository.UpdateAsync(newUser);

//    // Fetch the updated item
//    var updatedItem = (await repository.ListAsync())
//        .FirstOrDefault(User => User.FullName == newName);

//    Assert.NotNull(updatedItem);
//    Assert.NotEqual(user.FullName, updatedItem?.FullName);

//    Assert.Equal(newUser.Id, updatedItem?.Id);
//  }
//}
