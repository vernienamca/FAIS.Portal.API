using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
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

        public LibraryType GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<LibraryType> Add(LibraryTypeDTO libraryTypeDto)
        {
            try
            {
                var libraryType = new LibraryType()
                {
                    Name = libraryTypeDto.Name,
                    Code = libraryTypeDto.Code,
                    Description = libraryTypeDto.Description,
                    IsActive = libraryTypeDto.IsActive,
                    StatusDate = DateTime.Now,
                    CreatedBy = libraryTypeDto.CreatedBy,
                    CreatedAt = DateTime.Now
                };

                return await _repository.Add(libraryType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LibraryType> Update(int id)
        {
            var libraryType = _repository.GetById(id);

            libraryType.UpdatedAt = DateTime.Now;

            return await _repository.Update(libraryType);
        }
        public List<string> GetLibraryCodesById (int id, string libraryCode)
        {
            return _repository.GetLibraryCodesById(id, libraryCode);
        }
    }
}
