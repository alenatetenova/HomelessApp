using Homeless.Authorization.Entities;
using Homeless.Database;

namespace Homeless.Authorization.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HomelessDbContext _dbContext;

        public UserRepository(HomelessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetById(int id)
        {
            var user = _dbContext.User.FirstOrDefault(u => u.Id == id);

            return user;
        }

        public User GetByLoginAndPassword(string login, string password)
        {
            var user = _dbContext.User.FirstOrDefault(u => u.Login == login && u.Password == password);

            return user;
        }
    }
}
