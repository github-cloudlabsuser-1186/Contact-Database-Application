[TestFixture]
public class UserControllerTests
{
    private UserController _userController;

    [SetUp]
    public void Setup()
    {
        _userController = new UserController();
        UserController.userlist.Clear(); // Ensure the list is empty before each test
    }

    [Test]
    public void Index_ReturnsViewWithUsers()
    {
        var result = _userController.Index() as ViewResult;
        var model = result.Model as IEnumerable<User>;

        Assert.IsNotNull(result);
        Assert.IsNotNull(model);
    }

    [Test]
    public void Details_WithId_ReturnsViewWithUser()
    {
        var user = new User { Id = 1, Name = "Test User", Email = "test@example.com" };
        UserController.userlist.Add(user);

        var result = _userController.Details(1) as ViewResult;
        var model = result.Model as User;

        Assert.IsNotNull(result);
        Assert.IsNotNull(model);
        Assert.AreEqual(user, model);
    }

    [Test]
    public void Create_Post_ValidUser_AddsUserToList()
    {
        var user = new User { Id = 2, Name = "New User", Email = "new@example.com" };

        _userController.Create(user);

        Assert.Contains(user, UserController.userlist);
    }

    [Test]
    public void Edit_Post_ValidUser_UpdatesUserInList()
    {
        var user = new User { Id = 1, Name = "Test User", Email = "test@example.com" };
        UserController.userlist.Add(user);

        var updatedUser = new User { Id = 1, Name = "Updated User", Email = "updated@example.com" };

        _userController.Edit(1, updatedUser);

        Assert.AreEqual(updatedUser.Name, UserController.userlist.First(u => u.Id == 1).Name);
        Assert.AreEqual(updatedUser.Email, UserController.userlist.First(u => u.Id == 1).Email);
    }

    [Test]
    public void Delete_Post_WithId_RemovesUserFromList()
    {
        var user = new User { Id = 1, Name = "Test User", Email = "test@example.com" };
        UserController.userlist.Add(user);

        _userController.Delete(1, new FormCollection());

        Assert.IsFalse(UserController.userlist.Contains(user));
    }
}
