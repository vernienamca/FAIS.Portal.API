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
        Task<LibraryType> GetById(int id);
        IReadOnlyCollection<string> GetLibraryCodesById(int id, string libraryCode);
        IReadOnlyCollection<string> GetLibrarybyCodes(string libraryCode);
        Task<LibraryType> Add(AddLibraryTypeDTO dto);
        Task<LibraryType> Update(UpdateLibraryTypeDTO dto);
    }
}
