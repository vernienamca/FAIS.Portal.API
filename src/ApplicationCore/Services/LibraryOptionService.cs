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

        public IReadOnlyCollection<DropdownModel> GetLookupValues(string[] code)
        {
            return _repository.GetDropdownValues(code);
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

        public async Task<LibraryOptions> Update(LibraryOptionUpdateDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var option = _repository.GetById(dto.Id);
            option.LibraryTypeId = dto.LibraryTypeId;
            option.Code = dto.Code;
            option.Description = dto.Description;
            option.Remarks = dto.Remarks;
            option.Ranking = dto.Ranking;
            option.UDF1 = dto.UDF1;
            option.UDF2 = dto.UDF2;
            option.UDF3 = dto.UDF3;
            option.IsActive = dto.IsActive;

            if (option.IsActive != dto.IsActive)
                option.StatusDate = DateTime.Now;

            option.UpdatedBy = dto.UpdatedBy;
            option.UpdatedAt = DateTime.Now;

            return await _repository.Update(option);
        }
    }
}
