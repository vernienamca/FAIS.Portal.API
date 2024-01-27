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
        Task<Users> GetById(int id);
        Task<Users> GetByUserName(string userName);
        Task<Users> GetByTempKey(string tempKey);
        Task<Users> GetByEmailAddress(string emailAddress);
        Task<List<PermissionModel>> GetPermissions(int id);
        Task<Users> Add(Users test);
        Task<Users> Update(Users test);
    }
}
 