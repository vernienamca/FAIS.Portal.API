using FAIS.ApplicationCore.Entities.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface ILibraryTypeRepository
    {
        IQueryable<LibraryType> Get();
        LibraryType GetById(decimal id);
     
        List<string> GetLibraryNamesByCode(string libraryCode);


        Task<LibraryType> GetPositionIdByName(string positionName);



    }
}
