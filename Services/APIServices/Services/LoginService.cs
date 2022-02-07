using APIDomain.DTOs;
using APIDomain.Entities.User;
using APIDomain.Interfaces.Repositories;
using APIDomain.Interfaces.Services.User;
using APIDomain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace APIServices.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly SigningConfiguration _signingConfiguration;
        private readonly TokenConfiguration _tokenConfiguration;
        private readonly IConfiguration _configuration;

        public LoginService(IUserRepository userRepository, 
                            SigningConfiguration signingConfiguration, 
                            TokenConfiguration tokenConfiguration,
                            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
            _configuration = configuration;
        }

        public async Task<object> FindByLogin(LoginDto login)
        {
            var baseUser = new User();

            if (login != null && !string.IsNullOrWhiteSpace(login.Email))
            {
                baseUser = await _userRepository.FindByLogin(login.Email);
                if (baseUser == null)
                {
                    return new { authenticated = false, message = "Falha ao autenticar" };
                }
                else
                {
                    ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(login.Email),
                                              new[]
                                              {
                                                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //jti => id do token
                                                  new Claim(JwtRegisteredClaimNames.UniqueName, login.Email)
                                              });
                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds); //60 segundos

                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);

                    return SuccessObject(createDate, expirationDate, token, login);
                }
            }
            else
            {
                return null;
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, LoginDto login)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                userName = login.Email,
                message = "Usuário logado com sucesso"
            };
        }
    }
}
