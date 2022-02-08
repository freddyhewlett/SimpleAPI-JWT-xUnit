using APIDomain.DTOs.User;
using APIDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace APIServiceTest.Automapper
{
    public class UserMapper : BaseTestService
    {
        [Fact(DisplayName = "É possivel mapear os Modelos")]
        public void Mapping_Models_Possible()
        {
            var model = new UserModel()
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            var entityList = new List<APIDomain.Entities.User.User>();
            for (int i = 0; i < 5; i++)
            {
                var item = new APIDomain.Entities.User.User() 
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };
                entityList.Add(item);
            }

            //Model para User Entity
            var userEntity = Mapper.Map<APIDomain.Entities.User.User>(model);
            Assert.Equal(userEntity.Id, model.Id);
            Assert.Equal(userEntity.Name, model.Name);
            Assert.Equal(userEntity.Email, model.Email);
            Assert.Equal(userEntity.CreateDate, model.CreateDate);
            Assert.Equal(userEntity.UpdateDate, model.UpdateDate);

            //Entidade para DTO
            var userDto = Mapper.Map<UserDto>(userEntity);
            Assert.Equal(userDto.Id, userEntity.Id);
            Assert.Equal(userDto.Name, userEntity.Name);
            Assert.Equal(userDto.Email, userEntity.Email);
            Assert.Equal(userDto.CreateDate, userEntity.CreateDate);

            var userDtoCreateResult = Mapper.Map<UserDtoCreateResult>(userEntity);
            Assert.Equal(userDtoCreateResult.Id, userEntity.Id);
            Assert.Equal(userDtoCreateResult.Name, userEntity.Name);
            Assert.Equal(userDtoCreateResult.Email, userEntity.Email);
            Assert.Equal(userDtoCreateResult.CreateDate, userEntity.CreateDate);

            var userDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(userEntity);
            Assert.Equal(userDtoUpdateResult.Id, userEntity.Id);
            Assert.Equal(userDtoUpdateResult.Name, userEntity.Name);
            Assert.Equal(userDtoUpdateResult.Email, userEntity.Email);
            Assert.Equal(userDtoUpdateResult.UpdateDate, userEntity.UpdateDate);

            //Mapeamento de lista de Entidade para lista DTO
            var dtoList = Mapper.Map<List<UserDto>>(entityList);
            Assert.True(dtoList.Count() == entityList.Count());
            for (int i = 0; i < dtoList.Count(); i++)
            {
                Assert.Equal(dtoList[i].Id, entityList[i].Id);
                Assert.Equal(dtoList[i].Name, entityList[i].Name);
                Assert.Equal(dtoList[i].Email, entityList[i].Email);
                Assert.Equal(dtoList[i].CreateDate, entityList[i].CreateDate);
            }

            //DTO para Model
            var userModel = Mapper.Map<UserModel>(userDto);
            Assert.Equal(userModel.Id, userDto.Id);
            Assert.Equal(userModel.Name, userDto.Name);
            Assert.Equal(userModel.Email, userDto.Email);
            Assert.Equal(userModel.CreateDate, userDto.CreateDate);

            var userDtoCreate = Mapper.Map<UserDtoCreate>(userModel);
            Assert.Equal(userDtoCreate.Name, userModel.Name);
            Assert.Equal(userDtoCreate.Email, userModel.Email);

            var userDtoUpdate = Mapper.Map<UserDtoUpdate>(userModel);
            Assert.Equal(userDtoUpdate.Id, userModel.Id);
            Assert.Equal(userDtoUpdate.Name, userModel.Name);
            Assert.Equal(userDtoUpdate.Email, userModel.Email);
        }
    }
}
