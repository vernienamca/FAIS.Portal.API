using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface ILibraryTypeRepository
    {
        IQueryable<LibraryType> Get();
        public LibraryType GetById(int id);
        Task<LibraryType> Add(LibraryType libraryType);
        Task<LibraryType> Update(LibraryType libraryType);
        IReadOnlyCollection<string> GetLibraryCodesById(int id, string libraryCode);
        IReadOnlyCollection<string> GetLibrarybyCodes(string libraryCode);
        public LibraryType GetPositionIdByName(string positionName);
        public LibraryType GetLibraryTypeIdByCode(string description);
    }
}
