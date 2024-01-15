using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IUserRepository
    {
        IReadOnlyCollection<UserModel> Get();
        Task<User> GetById(int id);
        Task<User> GetByUserName(string userName);
        Task<List<PermissionModel>> GetPermissions(int id);
        Task<User> Add(User test);
        Task<User> Update(User test);
    }
}
 