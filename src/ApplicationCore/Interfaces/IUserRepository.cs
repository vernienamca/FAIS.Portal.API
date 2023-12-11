using FAIS.ApplicationCore.Entities.Security;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> Get();
        User GetById(decimal id);
        User GetByUserName(string userName);
        Task<User> LockedAccount(User user);
        Task<User> UpdateSignInAttempts(User user);
    }
}
