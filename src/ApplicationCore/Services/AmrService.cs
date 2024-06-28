using ArrayToExcel;
using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class AmrService : IAmrService
    {
        private readonly IAmrRepository _repository;
        private readonly IAmr100BatchRepository _amr100BatchRepository;
        private readonly IMapper _mapper;

        public AmrService(IAmrRepository repository, IAmr100BatchRepository amr100BatchRepository, IMapper mapper)
        {
            _repository = repository;
            _amr100BatchRepository = amr100BatchRepository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<AmrModel> Get()
        {
            return _repository.Get();
        }

        public IReadOnlyCollection<Amr100BatchModel> GetAmr100Batch()
        {
            return _amr100BatchRepository.Get();
        }

        public async Task<AmrModel> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Amr100BatchModel> GetAmr100BatchById(int id)
        {
            return await _amr100BatchRepository.GetById(id);
        }

        public async Task<Amr> Add(AddAmrDTO dto)
        {
            try
            {
                var amrDto = _mapper.Map<Amr>(dto);
                return await _repository.Add(amrDto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Amr100Batch> AddAmr100Batch(AddAmr100BatchDTO dto)
        { 
            var amr100batchDto = _mapper.Map<Amr100Batch>(dto);
            return await _amr100BatchRepository.Add(amr100batchDto);
        }

        public async Task<Amr> Update(UpdateAmrDTO dto)
        {
            try
            {
                var amr = _repository.GetById(dto.Id) ?? throw new Exception("Amr Id does not exist");

                if (amr.Result == null)
                    throw new ArgumentNullException("Amr not exist.");

                var mapper = _mapper.Map<Amr>(dto);
                mapper.CreatedBy = amr.Result.CreatedBy;
                mapper.CreatedAt = amr.Result.CreatedAt;
                return await _repository.Update(mapper);
            } 
            catch (Exception ex)             
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Amr> UpdateEncoding(int id)
        {
            try
            {
                var amr = _repository.GetByIdForEncoding(id) ?? throw new Exception("Amr Id does not exist");

                if (amr.Result == null)
                    throw new ArgumentNullException("Amr not exist.");

                amr.Result.DateSentEncoding = DateTime.Now;
                return await _repository.Update(amr.Result);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Amr100Batch> UpdateAmr100Batch(UpdateAmr100BatchDTO dto)
        {
            try
            {
                var amr = _amr100BatchRepository.GetById(dto.Id) ?? throw new Exception("Amr Batch Id does not exist.");

                if (amr.Result == null)
                    throw new ArgumentNullException("Amr Batch does not exist");

                var mapper = _mapper.Map<Amr100Batch>(dto);
                mapper.CreatedBy = amr.Result.CreatedBy;
                mapper.CreatedAt = amr.Result.CreatedAt;
                return await _amr100BatchRepository.Update(mapper);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public byte[] ExportAmrLogs()
        {
            return _repository.Get().ToExcel();
        }
    }
}