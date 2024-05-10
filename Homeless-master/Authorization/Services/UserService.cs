using Homeless.Authorization.Entities;
using Homeless.Authorization.Extensions;
using Homeless.Authorization.Models;
using Homeless.Authorization.Repositories;

namespace Homeless.Authorization.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            var user = _userRepository.GetByLoginAndPassword(request.Login, request.Password);

            if (user == null) return null;

            var token = _configuration.GenerateJwtToken(user); ;
            return new AuthenticateResponse { Token = token };
        }

        public User GetById(int id)
        {
            var user = _userRepository.GetById(id);

            if (user == null) return null;

            return user;
        }
    }
}
