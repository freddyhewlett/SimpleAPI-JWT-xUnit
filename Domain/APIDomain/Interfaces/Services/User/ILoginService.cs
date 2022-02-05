using APIDomain.DTOs;
using System;
using System.Threading.Tasks;

namespace APIDomain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto login);
    }
}
