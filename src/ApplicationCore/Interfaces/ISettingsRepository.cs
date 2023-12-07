using FAIS.ApplicationCore.Entities.Structure;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface ISettingsRepository
    {
        IQueryable<Settings> Get();
        Task<Settings> GetById(int id);
    }
}
