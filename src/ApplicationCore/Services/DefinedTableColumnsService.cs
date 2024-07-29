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
        private readonly IFieldDictionaryRepository _fieldDictionaryRepository;
        private readonly IMapper _mapper;

        public DefinedTableColumnsService(IDefinedTableColumnsRepository repository, IFieldDictionaryRepository fieldDictionaryRepository, IMapper mapper)
        {
            _repository = repository;
            _fieldDictionaryRepository = fieldDictionaryRepository;
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
            try
            {
                var definedTableColumnsDto = _mapper.Map<DefinedTableColumns>(dto);
                return await _repository.Add(definedTableColumnsDto);
            }
            catch (Exception ex) 
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<DefinedTableColumns> Update(DefinedTableColumnsDTO dto)
        {
            try
            {
                var definedTableColumns = _repository.GetById(dto.Id) ?? throw new Exception("Defined Table Columns Id does not exist");

                if (definedTableColumns.Result == null)
                    throw new ArgumentNullException("Defined Table Column not exist.");

                dto.UpdatedAt = DateTime.Now;
                if (definedTableColumns.Result.IsActive != dto.IsActive)
                {
                    if (_fieldDictionaryRepository.GetByColumnId(dto.Id).Result != null)
                        throw new ArgumentException("Defined Table Column is in use by Field Dictionary.");
                    dto.StatusDate = DateTime.Now;
                }

                var mapper = _mapper.Map<DefinedTableColumns>(dto);
                mapper.CreatedBy = definedTableColumns.Result.CreatedBy;
                mapper.CreatedAt = definedTableColumns.Result.CreatedAt;
                return await _repository.Update(mapper);
            }
            catch (Exception ex) 
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
