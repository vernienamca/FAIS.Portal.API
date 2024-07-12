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
    public class DefinedTablesService : IDefinedTablesService
    {
        private readonly IDefinedTablesRepository _repository;
        private readonly IMapper _mapper;

        public DefinedTablesService(IDefinedTablesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<DefinedTablesModel> Get()
        {
            return _repository.Get();
        }

        public async Task<DefinedTablesModel> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<DefinedTables> Add(DefinedTablesDTO dto)
        {
            var definedTablesDto = _mapper.Map<DefinedTables>(dto);
            return await _repository.Add(definedTablesDto);
        }

        public async Task<DefinedTables> Update(UpdateDefinedTablesDTO dto)
        {
            var definedTables = _repository.GetById(dto.Id) ?? throw new Exception("Defined Tables Id does not exist");

            if (definedTables.Result == null)
                throw new ArgumentNullException("Defined Tables not exist.");

            var mapper = _mapper.Map<DefinedTables>(dto);
            mapper.CreatedBy = definedTables.Result.CreatedBy;
            mapper.CreatedAt = definedTables.Result.CreatedAt;
            return await _repository.Update(mapper);
        }
    }
}
