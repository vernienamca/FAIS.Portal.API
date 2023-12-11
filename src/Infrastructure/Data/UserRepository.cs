using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class UserRepository : EFRepository<User, decimal>, IUserRepository
    {
        public UserRepository(FAISContext context) : base(context)
        {
        }

        public IQueryable<User> Get()
        {
            return _dbContext.Users;
        }

        public User GetById(decimal id)
        {
            return _dbContext.Users.Where(t => t.Id == id).ToList()[0];
        }

        public User GetByUserName(string userName)
        {
            return _dbContext.Users.Where(t => t.UserName == userName).ToList()[0];
        }

        public async Task<User> LockedAccount(User user)
        {
            return await UpdateAsync(user);
        }

        public async Task<User> UpdateSignInAttempts(User user)
        {
            return await UpdateAsync(user);
        }
    }
}
