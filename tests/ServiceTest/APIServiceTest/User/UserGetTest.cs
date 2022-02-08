using APIDomain.DTOs.User;
using APIDomain.Interfaces.Services.User;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace APIServiceTest.User
{
    public class UserGetTest : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o método Get")]
        public async Task Get_Method_Possible()
        {
            //Service Mock
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.Get(UserId)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            //Get de UserDto com Moq
            var result = await _service.Get(UserId);
            Assert.NotNull(result);
            Assert.True(result.Id == UserId);
            Assert.Equal(UserName, result.Name);

            //Service Mock nulo
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto) null));
            _service = _serviceMock.Object;

            //Get nulo
            var _record = await _service.Get(UserId);
            Assert.Null(_record);
        }
    }
}
