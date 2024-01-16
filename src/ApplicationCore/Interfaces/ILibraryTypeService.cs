using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using System.Linq;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface ILibraryTypeService
    {
        IQueryable<LibraryType> Get();
        LibraryType GetById(int id);
    }
}
