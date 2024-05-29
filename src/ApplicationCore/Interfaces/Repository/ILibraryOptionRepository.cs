using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface ILibraryOptionRepository
    {
        IReadOnlyCollection<LibraryOptionModel> GetAll();
        IReadOnlyCollection<LibraryOptionModel> GetDropdownValues(string code);
        Task<LibraryOptions> Add(LibraryOptions libraryOptionType);
        Task<LibraryOptions> Update(LibraryOptions libraryOptionType);
        Task Delete(int libraryOptionid);
    }
}
