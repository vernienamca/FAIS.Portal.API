using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> Get();
    }
}
