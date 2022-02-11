using APIDomain.DTOs.User;
using APIDomain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace WebAPITest.User.GetCall
{
    public class GetReturn
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar Get")]
        public async Task User_Get_From_Controller_Possible()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(new UserDto
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                CreateDate = DateTime.Now
            });

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.GetById(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UserDto;
            Assert.NotNull(resultValue);
            Assert.Equal(name, resultValue.Name);
            Assert.Equal(email, resultValue.Email);
        }
    }
}
