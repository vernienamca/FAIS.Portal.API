using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class DepreciationMethodsService : IDepreciationMethodsService
    {
        private readonly IDepreciationMethodsRepository _repository;
        private readonly IMapper _mapper;

        public DepreciationMethodsService(IDepreciationMethodsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<DepreciationMethodsModel> Get()
        {
            return _repository.Get();
        }

        public async Task<DepreciationMethodsModel> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<DepreciationMethods> Add(DepreciationMethodsDTO dto)
        {
            var depreciationMethodsDto = _mapper.Map<DepreciationMethods>(dto);
            return await _repository.Add(depreciationMethodsDto);
        }

        public async Task<DepreciationMethods> Update(UpdateDepreciationMethodsDTO dto)
        {
            var depreciationMethods = _repository.GetById(dto.Id) ?? throw new Exception("Depreciation Methods Id does not exist");

            if (depreciationMethods.Result == null)
                throw new ArgumentNullException("Depreciation Methods not exist.");

            var mapper = _mapper.Map<DepreciationMethods>(dto);
            mapper.CreatedBy = depreciationMethods.Result.CreatedBy;
            mapper.CreatedAt = depreciationMethods.Result.CreatedAt;
            return await _repository.Update(mapper);
        }
    }
}
