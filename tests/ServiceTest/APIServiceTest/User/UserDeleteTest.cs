using APIDomain.Interfaces.Services.User;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace APIServiceTest.User
{
    public class UserDeleteTest : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o método Delete")]
        public async Task Delete_Method_Possible()
        {
            //Service Mock p/ Delete
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            //Deletado True
            var deleted = await _service.Delete(UserId);
            Assert.True(deleted);

            //Service Mock p/ Delete
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            deleted = await _service.Delete(Guid.NewGuid());
            Assert.False(deleted);
        }
    }
}
