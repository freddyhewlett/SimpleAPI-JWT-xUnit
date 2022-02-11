using APIDomain.DTOs.User;
using APIDomain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace WebAPITest.User.CreateCall
{
    public class BadRequestCreateReturn
    {
        private UsersController _controller;

        [Fact(DisplayName = "Retorno de BadRequest com erro da ModelState")]
        public async Task User_Created_From_Controller_Possible()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Post(It.IsAny<UserDtoCreate>())).ReturnsAsync(new UserDtoCreateResult
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                CreateDate = DateTime.Now
            });

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "Campo obrigatório");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("https://localhost:44348");
            _controller.Url = url.Object;

            var userDtoCreate = new UserDtoCreate()
            {
                Email = email,
                Name = name
            };

            var result = await _controller.Post(userDtoCreate);
            Assert.True(result is BadRequestObjectResult);

            

        }
    }
}
