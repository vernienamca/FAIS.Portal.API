using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class LibraryTypeService : ILibraryTypeService
    {
        private readonly ILibraryTypeRepository _repository;
        private readonly IMapper _mapper;
        public LibraryTypeService(ILibraryTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<LibraryTypeModel> Get()
        {
            return _repository.Get();
        }

        public async Task<LibraryType> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public IReadOnlyCollection<string> GetLibraryCodesById (int id, string libraryCode)
        {
            return _repository.GetLibraryCodesById(id, libraryCode);
        }

        public IReadOnlyCollection<string> GetLibrarybyCodes(string libraryCode)
        {
            return _repository.GetLibrarybyCodes(libraryCode);
        }
        public async Task<LibraryType> Add(AddLibraryTypeDTO dto)
        {
            var libraryTypeDto = _mapper.Map<LibraryType>(dto);
            return await _repository.Add(libraryTypeDto);
        }

        public async Task<LibraryType> Update(UpdateLibraryTypeDTO dto)
        {
            var libraryType = _repository.GetById(dto.Id) ?? throw new Exception("Library Type ID does not exist");

            if (libraryType == null)
                throw new ArgumentNullException("Library Type not exist.");

            var mapper = _mapper.Map<LibraryType>(dto);
            mapper.CreatedBy = libraryType.Result.CreatedBy;
            mapper.CreatedAt = libraryType.Result.CreatedAt;
            return await _repository.Update(mapper);

        }
    }
}
