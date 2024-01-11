using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> Get();
        User GetById(decimal id);
        User GetByUserName(string userName);
        List<PermissionModel> GetPermissions(int id);
        Task<User> LockedAccount(User user);
        Task<User> UpdateSignInAttempts(User user);
        Task<User> Add(User user);
        Task<User> Update(User user);
    }
}
 