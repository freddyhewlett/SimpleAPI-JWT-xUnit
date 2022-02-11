using APIDomain.DTOs.User;
using APIDomain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace WebAPITest.User.GetAllCall
{
    public class BadRequestGetAllReturn
    {
        private UsersController _controller;

        [Fact(DisplayName = "Retorno de BadRequest de GetAll")]
        public async Task User_GetAll_BadRequest_From_Controller_Possible()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(new List<UserDto>
            {
                new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateDate = DateTime.Now
                },
                new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateDate = DateTime.Now
                }
            });

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
