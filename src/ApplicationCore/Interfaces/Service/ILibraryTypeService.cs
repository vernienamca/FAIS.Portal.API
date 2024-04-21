using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface ILibraryTypeService
    {
        IReadOnlyCollection<LibraryTypeModel> Get();
        LibraryType GetById(int id);
        IReadOnlyCollection<string> GetLookupByCode(int id, string code);
        IReadOnlyCollection<string> GetLibrarybyCodes(string libraryCode);
        Task<LibraryType> Add(AddLibraryTypeDTO dto);
        Task<LibraryType> Update(UpdateLibraryTypeDTO dto);
    }
}
