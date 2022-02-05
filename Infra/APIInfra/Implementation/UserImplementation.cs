using APIDomain.Entities.User;
using APIDomain.Interfaces.Repositories;
using APIInfra.Data;
using APIInfra.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace APIInfra.Implementation
{
    public class UserImplementation : BaseRepository<User>, IUserRepository
    {
        private DbSet<User> _dataSet;

        public UserImplementation(APIDbContext context) : base(context)
        {
            _dataSet = context.Set<User>();
        }

        public async Task<User> FindByLogin(string email)
        {
            return await _dataSet.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
