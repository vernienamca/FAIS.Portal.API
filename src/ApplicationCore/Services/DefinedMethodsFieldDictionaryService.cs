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
    public class DefinedMethodsFieldDictionaryService : IDefinedMethodsFieldDictionaryService
    {
        private readonly IDefinedMethodsFieldDictionaryRepository _repository;
        private readonly IMapper _mapper;

        public DefinedMethodsFieldDictionaryService(IDefinedMethodsFieldDictionaryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<DefinedMethodsFieldDictionaryModel> Get()
        {
            return _repository.Get();
        }

        public async Task<DefinedMethodsFieldDictionaryModel> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<DefinedMethodsFieldDictionary> Add(DefinedMethodsFieldDictionaryDTO dto)
        {
            try
            {
                var definedMethodsFieldDictionaryDto = _mapper.Map<DefinedMethodsFieldDictionary>(dto);
                return await _repository.Add(definedMethodsFieldDictionaryDto);
            }
            catch (Exception ex) 
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<DefinedMethodsFieldDictionary> Update(DefinedMethodsFieldDictionaryDTO dto)
        {
            try
            {
                var definedMethodsFieldDictionary = _repository.GetById(dto.Id) ?? throw new Exception("Defined Methods Field Dictionary Id does not exist");

                if (definedMethodsFieldDictionary.Result == null)
                    throw new ArgumentNullException("Defined Methods Field Dictionary not exist.");

                var mapper = _mapper.Map<DefinedMethodsFieldDictionary>(dto);
                mapper.CreatedBy = definedMethodsFieldDictionary.Result.CreatedBy;
                mapper.CreatedAt = definedMethodsFieldDictionary.Result.CreatedAt;
                return await _repository.Update(mapper);
            }
            catch (Exception ex) 
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
