using AutoMapper;
using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class LibraryOptionService : ILibraryOptionService
    {
        private readonly ILibraryOptionRepository _repository;
        private readonly IMapper _mapper;

        public LibraryOptionService(ILibraryOptionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<LibraryOptionModel> Get()
        {
            return _repository.GetAll();
        }

        public LibraryOptionModel GetById(int id)
        {
            return _repository.GetAll().Where(x=>x.Id == id).FirstOrDefault();
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task Add(LibraryOptionAddDto model)
        {
            await _repository.Add(_mapper.Map<LibraryOptions>(model));
        }

        public async Task Update(LibraryOptionUpdateDto model)
        {
            var libraryOption = _repository.GetAll().FirstOrDefault(libraryOption => libraryOption.Id == model.Id);            
            if (libraryOption == null)
            {
                throw new Exception("LibraryOptionId is not exist");
            }
            var mapper = _mapper.Map<LibraryOptions>(libraryOption);
            mapper.UpdatedBy = model.UpdatedBy;
            mapper.UpdatedAt = DateTime.Now;

            mapper.Description = model.Description;
            mapper.IsActive = model.IsActive;
            mapper.Code = model.Code;
            mapper.Remarks = model.Remark;
            await _repository.Update(mapper);
        }
    }
}
