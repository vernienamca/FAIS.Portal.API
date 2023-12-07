using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class UserRepository : EFRepository<User, int>, IUserRepository
    {
        public UserRepository(FAISContext context) : base(context)
        {
        }

        public IQueryable<User> Get()
        {
            return _dbContext.Users;
        }
    }
}
