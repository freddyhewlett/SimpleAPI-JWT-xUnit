using APIDomain.Entities.User;
using APIDomain.Interfaces.Repositories;
using APIDomain.Interfaces.Services.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


//TODO Criar projeto Service
namespace APIServices.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _repository;

        public UserService(IBaseRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<User> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _repository.SelectAllAsync();
        }

        public async Task<User> Post(User user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<User> Put(User user)
        {
            return await _repository.UpdateAsync(user);
        }
    }
}
