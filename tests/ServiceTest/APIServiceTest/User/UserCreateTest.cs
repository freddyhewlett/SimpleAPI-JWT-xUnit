using APIDomain.Interfaces.Services.User;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace APIServiceTest.User
{
    public class UserCreateTest : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o método Create")]
        public async Task Create_Method_Possible()
        {
            //Service Mock
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            //Metodo Post/Create
            var result = await _service.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(UserName, result.Name);
            Assert.Equal(UserEmail, result.Email);
        }
    }
}
