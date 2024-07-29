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
    public class FieldDictionaryService : IFieldDictionaryService
    {
        private readonly IFieldDictionaryRepository _repository;
        private readonly IMapper _mapper;

        public FieldDictionaryService(IFieldDictionaryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<FieldDictionaryModel> Get()
        {
            return _repository.Get();
        }

        public async Task<FieldDictionaryModel> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<FieldDictionary> Add(FieldDictionaryDTO dto)
        {
            try
            {
                var mapper = _mapper.Map<FieldDictionary>(dto);
                return await _repository.Add(mapper);
            }
            catch (Exception ex) 
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<FieldDictionary> Update(FieldDictionaryDTO dto)
        {
            try
            {
                var fieldDictionary = _repository.GetById(dto.Id) ?? throw new Exception("Field Dictionary Id does not exist");

                if (fieldDictionary.Result == null)
                    throw new ArgumentNullException("Field Dictionary not exist.");

                var mapper = _mapper.Map<FieldDictionary>(dto);
                mapper.CreatedBy = fieldDictionary.Result.CreatedBy;
                mapper.CreatedAt = fieldDictionary.Result.CreatedAt;
                return await _repository.Update(mapper);
            }
            catch (Exception ex) 
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
