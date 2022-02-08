using APIDomain.Entities.User;
using APIInfra.Data;
using APIInfra.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace APIInfraTest
{
    public class UserCompleteCrud : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public UserCompleteCrud(DbTest dBTest)
        {
            _serviceProvider = dBTest.ServiceProvider;
        }

        [Fact(DisplayName ="User CRUD")]
        [Trait("CRUD", "User Entity")]
        public async Task User_CRUD_Possible()
        {
            //Cria o banco de dados e deleta no final atraves do DbTest
            using (var context = _serviceProvider.GetService<APIDbContext>())
            {
                UserImplementation _repository = new UserImplementation(context);
                User _entity = new User
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                //Insert
                var _createdUser = await _repository.InsertAsync(_entity);
                Assert.NotNull(_createdUser);
                Assert.Equal(_entity.Email, _createdUser.Email);
                Assert.Equal(_entity.Name, _createdUser.Name);
                Assert.False(_createdUser.Id == Guid.Empty);

                //Update
                _entity.Name = Faker.Name.First();
                var _updatedUser = await _repository.UpdateAsync(_entity);
                Assert.NotNull(_updatedUser);
                Assert.Equal(_entity.Email, _updatedUser.Email);
                Assert.Equal(_entity.Name, _updatedUser.Name);

                //Exists
                var _userExists = await _repository.ExistsAsync(_updatedUser.Id);
                Assert.True(_userExists);

                //Select
                var _selectedUser = await _repository.SelectAsync(_updatedUser.Id);
                Assert.NotNull(_selectedUser);
                Assert.Equal(_updatedUser.Email, _selectedUser.Email);
                Assert.Equal(_updatedUser.Name, _selectedUser.Name);

                //SelectAll
                var _userList = await _repository.SelectAllAsync();
                Assert.NotNull(_userList);
                Assert.True(_userList.Count() > 0);

                //Delete
                var _deletedUser = await _repository.DeleteAsync(_selectedUser.Id);
                Assert.True(_deletedUser);

                //FindByLogin de UserImplementation
                var _baseUser = await _repository.FindByLogin("admin@mail.com");
                Assert.NotNull(_baseUser);
                Assert.Equal("admin@mail.com", _baseUser.Email);
                Assert.Equal("Admin", _baseUser.Name);
            }
        }
    }
}
