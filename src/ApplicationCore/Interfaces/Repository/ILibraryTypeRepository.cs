using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface ILibraryTypeRepository
    {
        IReadOnlyCollection<LibraryTypeModel> Get();
        Task<LibraryType> GetById(int id);
        Task<LibraryType> Add(LibraryType libraryType);
        Task<LibraryType> Update(LibraryType libraryType);
        LibraryType GetPositionIdByName(string positionName);
        LibraryType GetLibraryTypeIdByCode(string description);
        Task <LibraryType> GetByCode (string code);
    }
}
