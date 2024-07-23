﻿using ArrayToExcel;
using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Enumeration;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Linq;
using System.Data.Entity;
using System.Transactions;
using System.Diagnostics;

namespace FAIS.ApplicationCore.Services
{
    public class AmrService : IAmrService
    {
        private readonly IAmrRepository _repository;
        private readonly IAmr100BatchRepository _amr100BatchRepository;
        private readonly IAmr100BatchDRepository _amr100BatchDRepository;
        private readonly IAmr100BatchDbdRepository _amr100BatchDbdRepository;
        private readonly IAmr100BatchStatHistoryRepository _amr100BatchStatHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AmrService(IAmrRepository repository, IAmr100BatchRepository amr100BatchRepository,
            IAmr100BatchDRepository amr100BatchDRepository, IAmr100BatchDbdRepository amr100BatchDbdRepository, IAmr100BatchStatHistoryRepository amr100BatchStatHistoryRepository
            , IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _amr100BatchRepository = amr100BatchRepository;
            _amr100BatchDRepository = amr100BatchDRepository;
            _amr100BatchDbdRepository = amr100BatchDbdRepository;
            _amr100BatchStatHistoryRepository = amr100BatchStatHistoryRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public IReadOnlyCollection<AmrModel> Get()
        {
            return _repository.Get();
        }

        public IReadOnlyCollection<Amr100BatchModel> GetAmr100Batch(int reportSeqId, string yearMonth)
        {
            return _amr100BatchRepository.Get(reportSeqId, yearMonth);
        }
        public IReadOnlyCollection<Amr100BatchDModel> GetAmr100BatchD(int amrBatchSeq, int reportSeq, string yearMonth)
        {
            return _amr100BatchDRepository.Get(amrBatchSeq, reportSeq, yearMonth);
        }

        public IReadOnlyCollection<Amr100BatchDbdModel> GetAmr100BatchDbd(int amrBatchDSeq, int reportSeq, string yearMonth)
        {
            return _amr100BatchDbdRepository.Get(amrBatchSeq, reportSeq, yearMonth);
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

        public IReadOnlyCollection<Amr100BatchStatHistoryModel> GetAmr100BatchStatHistory()
        {
            return _amr100BatchStatHistoryRepository.Get();
        }

        public async Task<IReadOnlyCollection<Amr100BatchStatHistoryModel>> GetAmr100BatchStatHistoryById(int batchId)
        {
            return await _amr100BatchStatHistoryRepository.GetById(batchId);
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

        public async Task<List<Amr100BatchD>> SaveChanges(List<Amr100BatchDDTO> batchItems)
        {
            var result = new List<Amr100BatchD>();

            foreach (var dto in batchItems)
            {
                if (dto.TempId == null || dto.TempId == Guid.Empty)
                {
                    var amr100batchd = _mapper.Map<Amr100BatchD>(dto);
                    var added = await _amr100BatchDRepository.Add(amr100batchd);
                    result.Add(added);
                }
                else
                {
                    var amr100batchd = _mapper.Map<Amr100BatchD>(dto);
                    var added = await _amr100BatchDRepository.Update(amr100batchd);
                    result.Add(added);
                }
            }

            return result;
        }
        public async Task<Amr100BatchDbd> AddAmr100BatchDbd(AddAmr100BatchDbdDTO dto)
        {
            var amr100batchdbdDto = _mapper.Map<Amr100BatchDbd>(dto);
            return await _amr100BatchDbdRepository.Add(amr100batchdbdDto);
        }

        public async Task<Amr100BatchStatHistory> AddAmr100BatchStatHistory(Amr100BatchStatHistoryDTO amr100BatchStatHistoryDto)
        {
            try
            {
                var batchHistory = new Amr100BatchStatHistory()
                {
                    Amr100BatchSeq = amr100BatchStatHistoryDto.BatchSeq,
                    StatusCodeLto = amr100BatchStatHistoryDto.StatusCode,
                    StatusDate = amr100BatchStatHistoryDto.StatusDate,
                    StatusRemarks = amr100BatchStatHistoryDto.Remarks,
                    CreatedBy = amr100BatchStatHistoryDto.CreatedBy,
                };

                return await _amr100BatchStatHistoryRepository.Add(batchHistory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                amr.Result.StatusCode = (int)AmrStatusEnum.Open;
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
            catch (Exception e)
            {
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

        public byte[] ExportAmrBatchDLogs()
        {
            return _amr100BatchDRepository.GetAll().ToExcel();
        }
        public async Task<Amr100BatchD> ResetQuantity()
        {
            var timeOutConfig = _configuration.GetSection("BulkConfig")["BulkCopyTimeout"];
            int timeOutInSeconds = timeOutConfig != null ? Convert.ToInt32(timeOutConfig) : 0;
            var (data, mappedAmrSeq) = this.MapAmr100BatchD();
            var entitiesToDelete = _amr100BatchDbdRepository.GetAll().Where(e => mappedAmrSeq.Contains(e.Amr100BatchDSeq)).ToList();
            var bulkConfig = new BulkConfig { BatchSize = entitiesToDelete.Count(), BulkCopyTimeout = timeOutInSeconds };

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await _amr100BatchDbdRepository.BulkDelete(entitiesToDelete, bulkConfig);
                    await _amr100BatchDRepository.Update(data);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }
        public async Task<Amr100BatchD> BreakRow(int id)
        {
            var timeOutConfig = _configuration.GetSection("BulkConfig")["BulkCopyTimeout"];
            int timeOutInSeconds = timeOutConfig != null ? Convert.ToInt32(timeOutConfig) : 0;
            var amr100BatchD = await _amr100BatchDRepository.GetById(id) ?? throw new ArgumentException("Invalid Amr100BatchD sequence.");
            var (data, _) = this.MappedBatch(id);
            var unitsToInsert = amr100BatchD.Qty;
            var amrBatchdbdEnt = new List<Amr100BatchDbd>();
            var bulkConfig = new BulkConfig { BatchSize = amrBatchdbdEnt.Count(), BulkCopyTimeout = timeOutInSeconds };

            for (int i = 0; i < unitsToInsert; i++)
            {
                var newAmrBatchDbd = new Amr100BatchDbd
                {
                    Amr100BatchDSeq = amr100BatchD.Id,
                    AllocatedCost = amr100BatchD.AmrCost / unitsToInsert,
                    WithIssues = 'N',
                    CreatedAt = DateTime.Now,
                };

                amrBatchdbdEnt.Add(newAmrBatchDbd);
            }

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await _amr100BatchDbdRepository.BulkInsert(amrBatchdbdEnt, bulkConfig);
                    data.ForEach(amr => amr.ColumnBreaks = 1);
                    await _amr100BatchDRepository.Update(data);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }


    
        #region Private

        /// <summary>
        /// Maps the raw data to amr100 batch D.
        /// </summary>
        /// <returns></returns>
        private (List<Amr100BatchD>, List<int>) MapAmr100BatchD()
        {
            List<int> amr100BatchDIds = new List<int>();
            var amrs = _amr100BatchDRepository.GetAll().Where(x => x.Qty > 1).ToList();

            amrs.ForEach(amr =>
            {
                amr100BatchDIds.Add(amr.Id);
                amr.Qty = 1;
                amr.ColumnBreaks = 0;
            });

            return (amrs, amr100BatchDIds);
        }

        private (List<Amr100BatchD>, List<int>) MappedBatch(int id)
        {
            List<int> amr100BatchDIds = new List<int>();
            var amrs = _amr100BatchDRepository.GetAll().Where(x => x.Id == id).ToList();

            amrs.ForEach(amr =>
            {
                amr.ColumnBreaks = 1;
            });

            return (amrs, amr100BatchDIds);

        }

        #endregion Private
    }
}