using FAIS.ApplicationCore.Entities.Structure;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IModuleRepository
    {
        IQueryable<Module> Get();
        Task<Module> GetById(int id);
    }
}
