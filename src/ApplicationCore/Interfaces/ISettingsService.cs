using FAIS.ApplicationCore.Entities.Structure;
using System.Linq;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface ISettingsService
    {
        IQueryable<Settings> Get();
        Settings GetById(int id);
    }
}
