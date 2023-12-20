using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> Get();
        User GetById(decimal id);
        User GetByUserName(string userName);
        Task<User> LockedAccount(UserDTO userDTO);
        Task<User> UpdateSignInAttempts(UserDTO userDTO);

        Task<User> Add(UserDTO userDTO);
    }
}
