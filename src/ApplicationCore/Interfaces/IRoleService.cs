using FAIS.ApplicationCore.Entities.Security;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IRoleService
    {
        IQueryable<Role> Get();
        Task<Role> GetById(int id);
    }
}
