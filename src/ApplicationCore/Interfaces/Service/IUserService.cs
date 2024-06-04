using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IUserService
    {
        IReadOnlyCollection<UserModel> Get();
        Task<User> GetById(int id);
        IReadOnlyCollection<EmployeeModel> GetEmployees();
        Task<User> GetByUserName(string userName);
        Task<User> GetByTempKey(string tempKey);
        Task<User> GetByEmailAddress(string emailAddress);
        Task<List<PermissionModel>> GetPermissions(int id);
        Task<List<UserRoleModel>> GetUserRoles(int userId);
        string GeneratePassword();
        Task<User> Add(UserDTO userDto);
        Task<LoginHistory> AddLoginHistory(int userId, string username, bool isFailed = false);
        Task<DateTime?> GetLastLoginDate(int userId);
        Task<User> ResetPassword(string tempKey, string newPassword);
        Task<User> ChangePassword(int userId, string newPassword);
        Task<User> LockAccount(int id);
        Task<User> UpdateSignInAttempts(UserDTO userDto);
        Task<string> SetTemporaryKey(int id);
        Task<User> Update(User user);
        Task<string> WriteFile(IFormFile file, string directory);
        Task<int> GetLastUserId();
        void SetTAFGs(int userId, IReadOnlyCollection<int> userTAFGs);
        void SetUserRoles(int userId, IReadOnlyCollection<UserRoleDTO> userRoles);
        IReadOnlyCollection<int> GetUserTAFgs(int userId);
    }
}
