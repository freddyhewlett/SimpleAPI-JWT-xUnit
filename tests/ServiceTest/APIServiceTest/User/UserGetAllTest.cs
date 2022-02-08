using APIDomain.DTOs.User;
using APIDomain.Interfaces.Services.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace APIServiceTest.User
{
    public class UserGetAllTest : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o método GetAll")]
        public async Task GetAll_Method_Possible()
        {
            //Service Mock
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.GetAll()).ReturnsAsync(userDtoList);
            _service = _serviceMock.Object;

            //Metodo GetAll moq
            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            //Service Mock para nulo
            var _listResult = new List<UserDto>();
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            //Metodo GetAll com retorno nulo
            var _emptyResult = await _service.GetAll();
            Assert.Empty(_emptyResult);
            Assert.True(_emptyResult.Count() == 0);
        }
    }
}
