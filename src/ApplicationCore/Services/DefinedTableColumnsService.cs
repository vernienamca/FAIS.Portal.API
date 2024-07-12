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
    public class DefinedTableColumnsService : IDefinedTableColumnsService
    {
        private readonly IDefinedTableColumnsRepository _repository;
        private readonly IMapper _mapper;

        public DefinedTableColumnsService(IDefinedTableColumnsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<DefinedTableColumnsModel> Get()
        {
            return _repository.Get();
        }

        public async Task<DefinedTableColumnsModel> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<DefinedTableColumns> Add(DefinedTableColumnsDTO dto)
        {
            var definedTableColumnsDto = _mapper.Map<DefinedTableColumns>(dto);
            return await _repository.Add(definedTableColumnsDto);
        }

        public async Task<DefinedTableColumns> Update(UpdateDefinedTableColumnsDTO dto)
        {
            var definedTableColumns = _repository.GetById(dto.Id) ?? throw new Exception("Defined Table Columns Id does not exist");

            if (definedTableColumns.Result == null)
                throw new ArgumentNullException("Defined Table Columns not exist.");

            var mapper = _mapper.Map<DefinedTableColumns>(dto);
            mapper.CreatedBy = definedTableColumns.Result.CreatedBy;
            mapper.CreatedAt = definedTableColumns.Result.CreatedAt;
            return await _repository.Update(mapper);
        }
    }
}
