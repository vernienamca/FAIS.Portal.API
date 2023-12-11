using FAIS.ApplicationCore.Entities.Structure;
using System.Linq;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface ILibraryTypeRepository
    {
        IQueryable<LibraryType> Get();
        LibraryType GetById(decimal id);
    }
}
