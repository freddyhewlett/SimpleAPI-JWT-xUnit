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
    public class BadRequestDeletedReturn
    {
        private UsersController _controller;

        [Fact(DisplayName = "Retorno de BadRequest de Deleted")]
        public async Task User_Deleted_BadRequest_From_Controller_Possible()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido");

            var result = await _controller.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
