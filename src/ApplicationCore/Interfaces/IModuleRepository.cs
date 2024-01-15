using FAIS.ApplicationCore.Entities.Structure;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IModuleRepository
    {
        IQueryable<Module> Get();
        Module GetById(int id);
        Task<Module> Add(Module module);
        Task<Module> Update(Module module);
        Task Delete(Module module);
    }
}
