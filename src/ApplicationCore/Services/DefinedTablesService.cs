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
        private readonly IFieldDictionaryRepository _fieldDictionaryRepository;
        private readonly IMapper _mapper;

        public DefinedTablesService(IDefinedTablesRepository repository, IFieldDictionaryRepository fieldDictionaryRepository, IMapper mapper)
        {
            _repository = repository;
            _fieldDictionaryRepository = fieldDictionaryRepository;
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
            try
            {
                var definedTablesDto = _mapper.Map<DefinedTables>(dto);
                return await _repository.Add(definedTablesDto);
            }
            catch (Exception ex) 
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<DefinedTables> Update(DefinedTablesDTO dto)
        {
            try
            {
                var definedTables = _repository.GetById(dto.Id) ?? throw new Exception("Defined Table Id does not exist");

                if (definedTables.Result == null)
                    throw new ArgumentNullException("Defined Table not exist.");

                dto.UpdatedAt = DateTime.Now;
                if (definedTables.Result.IsActive != dto.IsActive)
                {
                    if (_fieldDictionaryRepository.GetByTableId(dto.Id).Result != null)
                        throw new ArgumentNullException("Defined Table is in use by active field dictionary.");
                    dto.StatusDate = DateTime.Now;
                }

                var mapper = _mapper.Map<DefinedTables>(dto);
                mapper.CreatedBy = definedTables.Result.CreatedBy;
                mapper.CreatedAt = definedTables.Result.CreatedAt;
                return await _repository.Update(mapper);
            }
            catch(Exception ex) 
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
