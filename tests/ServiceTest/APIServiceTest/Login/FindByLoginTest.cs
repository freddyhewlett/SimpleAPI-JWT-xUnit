using APIDomain.DTOs;
using APIDomain.Interfaces.Services.User;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace APIServiceTest.Login
{
    public class FindByLoginTest
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o método FindByLogin")]
        public async Task FindByLogin_Method_Possible()
        {
            var email = Faker.Internet.Email();
            var returnObject = new
            {
                authenticated = true,
                created = DateTime.Now,
                expiration = DateTime.Now.AddHours(12),
                accessToken = Guid.NewGuid(),
                userName = email,
                message = "Usuário logado com sucesso"
            };

            var loginDto = new LoginDto()
            {
                Email = email
            };

            //Service Mock
            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(s => s.FindByLogin(loginDto)).ReturnsAsync(returnObject);
            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(loginDto);
            Assert.NotNull(result);
        }
    }
}
