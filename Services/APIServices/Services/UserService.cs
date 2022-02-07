using APIDomain.DTOs.User;
using APIDomain.Entities.User;
using APIDomain.Interfaces.Repositories;
using APIDomain.Interfaces.Services.User;
using APIDomain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace APIServices.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IBaseRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            return _mapper.Map<UserDto>(await _repository.SelectAsync(id));
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<UserDto>>(await _repository.SelectAllAsync());
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<User>(model);
            return _mapper.Map<UserDtoCreateResult>(await _repository.InsertAsync(entity));
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<User>(model);
            return _mapper.Map<UserDtoUpdateResult>(await _repository.UpdateAsync(entity));
        }
    }
}
