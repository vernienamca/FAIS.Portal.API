using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface ILibraryOptionService
    {
        IReadOnlyCollection<LibraryOptionModel> Get();
        public IReadOnlyCollection<DropdownModel> GetDropdownValues(string[] code);
        LibraryOptionModel GetById(int id);
        Task Delete(int id);
        Task Add(LibraryOptionAddDto model);
        Task<LibraryOptions> Update(LibraryOptionUpdateDto model);
    }
}
