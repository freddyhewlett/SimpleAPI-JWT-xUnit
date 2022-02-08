using APIDomain.Interfaces.Services.User;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace APIServiceTest.User
{
    public class UserUpdateTest : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o método Update")]
        public async Task Update_Method_Possible()
        {
            //Service Mock p/ Create
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            //Metodo Post/Create
            var result = await _service.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(UserName, result.Name);
            Assert.Equal(UserEmail, result.Email);

            //Service Mock p/ Update
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
            _service = _serviceMock.Object;

            //Metodo Post/Create
            var resultUpdate = await _service.Put(userDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(UserNameModified, resultUpdate.Name);
            Assert.Equal(UserEmailModified, resultUpdate.Email);
        }
    }
}
