using APIDomain.DTOs;
using APIDomain.Interfaces.Repositories;
using APIDomain.Interfaces.Services.User;
using System;
using System.Threading.Tasks;

namespace APIServices.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<object> FindByLogin(LoginDto login)
        {
            if (login != null && !string.IsNullOrWhiteSpace(login.Email))
            {
                return await _userRepository.FindByLogin(login.Email);
            }
            else
            {
                return null;
            }
        }
    }
}
