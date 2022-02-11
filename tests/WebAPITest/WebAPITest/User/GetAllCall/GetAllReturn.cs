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
    public class GetAllReturn
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar GetAll")]
        public async Task User_GetAll_From_Controller_Possible()
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

            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as IEnumerable<UserDto>;
            Assert.True(resultValue.Count() == 2);
        }
    }
}
