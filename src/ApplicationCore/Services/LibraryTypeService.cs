using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class LibraryTypeService : ILibraryTypeService
    {
        private readonly ILibraryTypeRepository _repository;

        public LibraryTypeService(ILibraryTypeRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<LibraryType> Get()
        {
            return _repository.Get();
        }

        public LibraryType GetById(decimal id)
        {
            return _repository.GetById(id);
        }

        public List<string> GetLibraryNamesByCode(string libraryCode)
        {
            return _repository.GetLibraryNamesByCode(libraryCode);
        }

        public async Task<LibraryType> GetPositionIdByName(string positionName)
        {
            return await _repository.GetPositionIdByName(positionName);
        }


    }
}
