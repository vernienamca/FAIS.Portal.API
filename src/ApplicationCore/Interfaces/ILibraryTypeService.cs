using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface ILibraryTypeService
    {
        IQueryable<LibraryType> Get();
        LibraryType GetById(int id);
        IReadOnlyCollection<string> GetLibraryCodesById(int id, string libraryCode);
        IReadOnlyCollection<string> GetLibrarybyCodes(string libraryCode);
        Task<LibraryType> Update(int id);
        Task Delete(int id);
        Task<LibraryType> Add(LibraryType libraryType);
    }
}
