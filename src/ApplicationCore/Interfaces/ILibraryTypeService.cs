using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Linq;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface ILibraryTypeService
    {
        IQueryable<LibraryType> Get();
        LibraryType GetById(int id);
        IReadOnlyCollection<string> GetLibraryCodesById(int id, string libraryCode);
    }
}
