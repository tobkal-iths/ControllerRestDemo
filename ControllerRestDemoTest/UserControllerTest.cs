namespace ControllerRestDemoTest;

public class UserControllerTest
{
    [Fact]
    public async Task GetUsers_Returns_All_Users()
    {
        //Arrange
        var count = 5;
        var fakeUsers = A.CollectionOfDummy<User>(count).AsEnumerable();
        var unitOfWork = A.Fake<IUnitOfWork>();
        A.CallTo(() => unitOfWork.UserRepository.GetAllUsers()).Returns(fakeUsers);
        var controller = new UserController(unitOfWork);

        //Act
        var actionResults = await controller.Get();

        //Assert
        var result = actionResults.Result as OkObjectResult;
        var returnUsers = result.Value as IEnumerable<User>;
        Assert.Equal(count, returnUsers.Count());
    }

    [Fact]
    public async Task PostUser_Saves_User()
    {
        //Arrange
        var fakeUser = A.Dummy<User>();
        var unitOfWork = A.Fake<IUnitOfWork>();
        A.CallTo(() => unitOfWork.UserRepository.Create(fakeUser)).Returns(true);
        var controller = new UserController(unitOfWork);

        //Act
        var actionResult = await controller.Post(fakeUser);

        //Assert
        Assert.True(actionResult is OkResult);
    }

    [Fact]
    public async Task PostUser_Does_Not_Save_Existing_User()
    {
        //Arrange
        var fakeUser = A.Dummy<User>();
        var unitOfWork = A.Fake<IUnitOfWork>();
        A.CallTo(() => unitOfWork.UserRepository.Create(fakeUser)).Returns(false);
        var controller = new UserController(unitOfWork);

        //Act
        var actionResult = await controller.Post(fakeUser);

        //Assert
        Assert.True(actionResult is BadRequestResult);
    }
}
