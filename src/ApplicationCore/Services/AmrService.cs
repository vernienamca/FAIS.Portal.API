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
        private readonly IAmr100BatchDRepository _amr100BatchDRepository;
        private readonly IAmr100BatchDbdRepository _amr100BatchDbdRepository;
        private readonly IMapper _mapper;

        public AmrService(IAmrRepository repository, IAmr100BatchRepository amr100BatchRepository, 
            IAmr100BatchDRepository amr100BatchDRepository, IAmr100BatchDbdRepository amr100BatchDbdRepository, IMapper mapper)
        {
            _repository = repository;
            _amr100BatchRepository = amr100BatchRepository;
            _amr100BatchDRepository = amr100BatchDRepository;
            _amr100BatchDbdRepository = amr100BatchDbdRepository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<AmrModel> Get()
        {
            return _repository.Get();
        }

        //public IReadOnlyCollection<Amr100BatchModel> GetAmr100Batch(int id, DateTime yearMonth)
        //{
        //    return _amr100BatchRepository.Get(id, yearMonth);
        //}
        public IReadOnlyCollection<Amr100BatchModel> GetAmr100Batch(int id, string yearMonth)
        {
            return _amr100BatchRepository.Get(id, yearMonth);
        }
        public IReadOnlyCollection<Amr100BatchDModel> GetAmr100BatchD() { 
            return _amr100BatchDRepository.Get();
        }  
        
        public IReadOnlyCollection<Amr100BatchDbdModel> GetAmr100BatchDbd() { 
            return _amr100BatchDbdRepository.Get();
        }

        public async Task<AmrModel> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Amr100BatchModel> GetAmr100BatchById(int ReportSeq)
        {
            return await _amr100BatchRepository.GetById(ReportSeq);
        }
        
        public async Task<Amr100BatchDModel> GetAmr100BatchDById(int id)
        {
            return await _amr100BatchDRepository.GetById(id);
        }
          public async Task<Amr100BatchDbdModel> GetAmr100BatchDbdById(int id)
        {
            return await _amr100BatchDbdRepository.GetById(id);
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

        public async Task<Amr100BatchD> AddAmr100BatchD(AddAmr100BatchDDTO dto)
        {
            var amr100batchdDto = _mapper.Map<Amr100BatchD>(dto);
            return await _amr100BatchDRepository.Add(amr100batchdDto);
        }
        
        public async Task<Amr100BatchDbd> AddAmr100BatchDbd(AddAmr100BatchDbdDTO dto)
        {
            var amr100batchdbdDto = _mapper.Map<Amr100BatchDbd>(dto);
            return await _amr100BatchDbdRepository.Add(amr100batchdbdDto);
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
        public async Task<Amr100BatchD> UpdateAmr100BatchD(UpdateAmr100BatchDDTO dto)
        {
            try
            {
                var amr = _amr100BatchDRepository.GetById(dto.Id) ?? throw new Exception("Amr Batch Id does not exist.");

                if (amr.Result == null)
                    throw new ArgumentNullException("Amr Batch does not exist.");

                var mapper = _mapper.Map<Amr100BatchD>(dto);
                mapper.CreatedBy = amr.Result.CreatedBy;
                mapper.CreatedAt = amr.Result.CreatedAt;
                return await _amr100BatchDRepository.Update(mapper);
            }
            catch (Exception e) { 
                throw new Exception(e.Message);
            }

        }  

        public async Task<Amr100BatchDbd> UpdateAmr100BatchDbd(UpdateAmr100BatchDbdDTO dto)
        {
            try
            {
                var amr = _amr100BatchDbdRepository.GetById(dto.Id) ?? throw new Exception("Amr Batch Id does not exist.");

                if (amr.Result == null)
                    throw new ArgumentNullException("Amr Batch does not exist.");

                var mapper = _mapper.Map<Amr100BatchDbd>(dto);
                mapper.CreatedBy = amr.Result.CreatedBy;
                mapper.CreatedAt = amr.Result.CreatedAt;
                return await _amr100BatchDbdRepository.Update(mapper);
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