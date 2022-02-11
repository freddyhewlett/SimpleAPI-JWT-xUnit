using APIDomain.DTOs.User;
using APIDomain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace WebAPITest.User.DeleteCall
{
    public class DeletedReturn
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar Deleted")]
        public async Task User_Deleted_From_Controller_Possible()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new UsersController(serviceMock.Object);


            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True((bool)resultValue);
        }
    }
}
