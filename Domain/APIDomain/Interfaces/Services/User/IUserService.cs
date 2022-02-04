using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIDomain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<Entities.User.User> Get(Guid id);
        Task<IEnumerable<Entities.User.User>> GetAll();
        Task<Entities.User.User> Post(Entities.User.User user);
        Task<Entities.User.User> Put(Entities.User.User user);
        Task<bool> Delete(Guid id);
    }
}
