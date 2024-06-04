using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface ILibraryOptionRepository
    {
        IReadOnlyCollection<LibraryOptionModel> GetAll();
        LibraryOptions GetById(int id);
        IReadOnlyCollection<DropdownModel> GetLookupValues(string[] codes);
        Task<LibraryOptions> Add(LibraryOptions libraryOptionType);
        Task<LibraryOptions> Update(LibraryOptions libraryOptionType);
        Task Delete(int libraryOptionid);
    }
}
