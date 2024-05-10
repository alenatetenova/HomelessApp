using Homeless.Authorization.Entities;

namespace Homeless.Authorization.Repositories
{
    public interface IUserRepository
    {
        User GetByLoginAndPassword(string login, string password);
        User GetById(int id);
    }
}
