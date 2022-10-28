using ControllerRestDemo.Controllers;
using ControllerRestDemo.DAL;
using ControllerRestDemo.DAL.Models;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllerRestDemoTest
{
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
            var unitOfWork = A.Fake<IUnitOfWork>();
            var controller = new UserController(unitOfWork);

            var user = new User()
            {
                Id = 1,
                Email = "a@a.com",
                Name = "Niklas"
            };

            //Act
            var actionResult = await controller.Post(user);

            //Assert
            
            Assert.True(actionResult is OkResult);
        }
    }
}