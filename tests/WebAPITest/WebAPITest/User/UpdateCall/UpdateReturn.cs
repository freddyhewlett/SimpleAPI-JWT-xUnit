using APIDomain.DTOs.User;
using APIDomain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace WebAPITest.User.UpdateCall
{
    public class UpdateReturn
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar Updated")]
        public async Task User_Updated_From_Controller_Possible()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(new UserDtoUpdateResult
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                UpdateDate = DateTime.Now
            });

            _controller = new UsersController(serviceMock.Object);

            var userDtoUpdate = new UserDtoUpdate()
            {
                Id = Guid.NewGuid(),
                Email = email,
                Name = name
            };

            var result = await _controller.Put(userDtoUpdate);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UserDtoUpdateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(userDtoUpdate.Name, resultValue.Name);
            Assert.Equal(userDtoUpdate.Email, resultValue.Email);
        }
    }
}
