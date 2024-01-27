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
        IReadOnlyCollection<UserModel> Get();
        Task<Users> GetById(int id);
        Task<Users> GetByUserName(string userName);
        Task<Users> GetByTempKey(string tempKey);
        Task<Users> GetByEmailAddress(string emailAddress);
        Task<List<PermissionModel>> GetPermissions(int id);
        Task<Users> Add(UserDTO userDto);
        Task<LoginHistory> AddLoginHistory(int userId, string username, bool isFailed = false);
        Task<User> ResetPassword(string tempKey, string newPassword);
        Task<User> ChangePassword(int userId, string newPassword);
        Task<User> LockAccount(int id);
        Task<User> UpdateSignInAttempts(UserDTO userDto);
        Task<Users> ResetPassword(string tempKey, string newPassword);
        Task<Users> LockAccount(int id);
        Task<Users> UpdateSignInAttempts(UserDTO userDto);
        Task<string> SetTemporaryKey(int id);
    }
}
