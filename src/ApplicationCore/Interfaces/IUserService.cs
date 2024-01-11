using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> Get();
        User GetById(decimal id);
        User GetByUserName(string userName);
        List<PermissionModel> GetPermissions(int id);
        Task<User> LockedAccount(UserDTO userDTO);
        Task<User> UpdateSignInAttempts(UserDTO userDTO);
        Task<User> Add(UserDTO userDTO);
        Task<User> Update(UserDTO userDTO);
        Task<LoginHistory> AddLoginHistory(decimal userId, string username, bool isFailed);
    }
}
