using Homeless.Authorization.Entities;
using Homeless.Authorization.Models;

namespace Homeless.Authorization.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest request);
        User GetById(int id);
    }
}
