using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
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
        Task<User> GetByTempKey(string tempKey);
        Task<User> GetByEmailAddress(string emailAddress);
        Task<List<PermissionModel>> GetPermissions(int id);
        Task<User> Add(User test);
        Task <User> Update(User user);
        Task<int> GetLastUserId();
        Task AddTAFGs(IReadOnlyCollection<UserTAFG> userTAFGs);
        Task<string> WriteFile(IFormFile file, string directory);
    }
}
 