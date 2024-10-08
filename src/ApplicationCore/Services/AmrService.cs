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
using DocumentFormat.OpenXml.Office2010.Excel;

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

        public IReadOnlyCollection<Amr100BatchDbdModel> GetAmr100BatchDbd(int amrBatchSeq, int reportSeq, string yearMonth)
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

        public async Task<Amr100BatchD> ResetQuantity(int amrBatchSeq)
        {
            var (data, mappedAmrSeq) = this.MapAmr100BatchD(amrBatchSeq);
            var entitiesToDelete = _amr100BatchDbdRepository.GetAll().Where(e => mappedAmrSeq.Contains(e.Amr100BatchDSeq)).ToList();

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await _amr100BatchDbdRepository.RemoveMultipleRecords(entitiesToDelete);
                    await _amr100BatchDRepository.UpdateMultipleRecords(data);
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
            var amrBatchDbdEnt = new List<Amr100BatchDbd>();
            var amr = await _amr100BatchDRepository.GetBatchDById(id);

            if (amr == null)
                throw new ArgumentNullException("Amr Batch does not exist");
            
            try
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var units = amr.Qty;
                    for (var i = 0; i < units; i++)
                    {
                        var newAmrBatchDbd = new Amr100BatchDbd
                        {
                            Amr100BatchDSeq = amr.Id,
                            AllocatedCost = amr.AmrCost / units,
                            WithIssues = 'N',
                            CreatedBy = amr.CreatedBy,
                            CreatedAt = DateTime.Now,
                        };
                        amrBatchDbdEnt.Add(newAmrBatchDbd);
                    }

                    amr.ColumnBreaks = 1;
                    await _amr100BatchDbdRepository.InsertMultipleRecords(amrBatchDbdEnt);
                    await _amr100BatchDRepository.Update(amr);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }
        public async Task<List<Amr100BatchD>> BreakMultipleRows(int amrBatchSeq)
        {
            var (data, mappedAmrSeq) = this.MapBatchD(amrBatchSeq);
            var amrBatchDbdEnt = new List<Amr100BatchDbd>();


            if (data == null)
                throw new ArgumentNullException("No Amr Batch records exist");

            try
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    foreach (var amrs in data)
                    {
                        var units = amrs.Qty;
                        for (var i = 0; i < units; i++)
                        {
                            var newAmrBatchDbd = new Amr100BatchDbd
                            {
                                Amr100BatchDSeq = amrs.Id,
                                AllocatedCost = amrs.AmrCost / units,
                                WithIssues = 'N',
                                CreatedBy = amrs.CreatedBy,
                                CreatedAt = DateTime.Now,
                            };
                            amrBatchDbdEnt.Add(newAmrBatchDbd);
                        }
                    }
                    await _amr100BatchDbdRepository.InsertMultipleRecords(amrBatchDbdEnt);
                    await _amr100BatchDRepository.UpdateMultipleRecords(data);

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while breaking multiple rows", ex);
            }

            return null;
        }


        public async Task<Amr100BatchD> RemoveBreak(int id)
        {
            var entitiesToDelete = _amr100BatchDbdRepository.GetAll().Where(dbd => dbd.Amr100BatchDSeq == id).ToList();
            var amr = _amr100BatchDRepository.GetBatchDById(id);

            if (amr == null)
                throw new ArgumentNullException("Amr Batch does not exist.");

            try
            {
                amr.Result.ColumnBreaks = 0;
                amr.Result.Qty = 1;
                await _amr100BatchDRepository.Update(amr.Result);
                await _amr100BatchDbdRepository.RemoveMultipleRecords(entitiesToDelete);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public async Task<List<Amr100BatchD>> SaveChanges(List<Amr100BatchDDTO> dtos)
        {
            var result = new List<Amr100BatchD>();

            foreach (var dto in dtos)
            {
                if (dto.TempId != null && dto.TempId != Guid.Empty)
                {
                    var entitiesToInsert = _mapper.Map<Amr100BatchD>(dto);
                    var added = await _amr100BatchDRepository.Add(entitiesToInsert);
                    result.Add(added);
                    continue;
                }
                var amr100batchd = _mapper.Map<Amr100BatchD>(dto);
                var update = await _amr100BatchDRepository.Update(amr100batchd);
                result.Add(update);
            }
            return result;
        }
        public async Task<List<Amr100BatchDbd>> UpdateRows(List<UpdateAmr100BatchDbdDTO> dtos)
        {
            var amrList = new List<Amr100BatchDbd>();

            foreach (var item in dtos)
            {
                var amr = _mapper.Map<Amr100BatchDbd>(item);
                amr.UpdatedBy = item.UpdatedBy;
                amr.UpdatedAt = item.UpdatedAt ?? DateTime.UtcNow;
                await _amr100BatchDbdRepository.Update(amr);
                amrList.Add(amr);
            }

            return amrList;
        }
        public async Task<Amr100Batch> NewAssetApproval(int id)
        {
           var batch = _amr100BatchRepository.GetAmr100Batch(id);

           batch.Result.StatusCode = (int)AmrStatusEnum.NewAsset;
           return await _amr100BatchRepository.Update(batch.Result);
        }

        public async Task<Amr100Batch> ReturnToAnalyst(AmrTransactionsDTO dto)
        {
            var batch = _amr100BatchRepository.GetAmr100Batch(dto.Id);

            batch.Result.StatusCode = (int)AmrStatusEnum.Open;
            batch.Result.Remarks = dto.Remarks;
            return await _amr100BatchRepository.Update(batch.Result);
        }

        public async Task<Amr100Batch> ForReview(int id)
        {
            var batch = _amr100BatchRepository.GetAmr100Batch(id);

            batch.Result.StatusCode = (int)AmrStatusEnum.ForReview;
            return await _amr100BatchRepository.Update(batch.Result);
        }

        #region Private

        /// <summary>
        /// Maps the raw data to amr100 batch D.
        /// </summary>
        /// <returns></returns>
        private (List<Amr100BatchD>, List<int>) MapAmr100BatchD(int amrBatchSeq)
        {
            List<int> amr100BatchDIds = new List<int>();
            var amrs = _amr100BatchDRepository.GetAll().Where(x => x.Amr100BatchSeq == amrBatchSeq && x.Qty > 1).ToList();

            amrs.ForEach(amr =>
            {
                amr100BatchDIds.Add(amr.Id);
                amr.Qty = 1;
                amr.ColumnBreaks = 0;
            });

            return (amrs, amr100BatchDIds);
        }       
        private (List<Amr100BatchD>, List<int>) MapBatchD(int amrBatchSeq)
        {
            List<int> amr100BatchDIds = new List<int>();
            var amrs = _amr100BatchDRepository.GetAll().Where(x => x.Amr100BatchSeq == amrBatchSeq).ToList();

            amrs.ForEach(amr =>
            {
                amr100BatchDIds.Add(amr.Id);
                amr.ColumnBreaks = 1;
            });

            return (amrs, amr100BatchDIds);
        }

        #endregion Private
    }
}