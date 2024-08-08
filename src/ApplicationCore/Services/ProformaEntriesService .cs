using AutoMapper;
using DocumentFormat.OpenXml.Vml.Office;
using DocumentFormat.OpenXml.Wordprocessing;
using FAIS.ApplicationCore.BusinessRules;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class ProformaEntriesService : IProformaEntriesService
    {
        private readonly IProformaEntriesRepository _repository;
        private readonly IProformaEntryDetailsRepository _detailsRepository;
        private readonly IMapper _mapper;

        public ProformaEntriesService(IProformaEntriesRepository repository, IProformaEntryDetailsRepository detailsRepository, IMapper mapper)
        {
            _repository = repository;
            _detailsRepository = detailsRepository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<ProformaEntry> Get()
        {
            return _repository.Get();
        }

        public ProformaEntry GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IReadOnlyCollection<ProformaEntryDetail> GetDetailById(int id)
        {
            return _detailsRepository.GetById(id);
        }

        public async Task<ProformaEntry> Add(ProformaEntryDTO proformaEntryDTO)
        {
            ProformaEntry proformaEntry = new ProformaEntry()
            {
                TranTypeSeq = proformaEntryDTO.TranTypeSeq,
                Description = proformaEntryDTO.Description,
                IsActive = proformaEntryDTO.IsActive,
                StatusDate = DateTime.Now,
                CreatedBy = proformaEntryDTO.CreatedBy,
                CreatedAt = DateTime.Now
            };

            var result = await _repository.Add(proformaEntry);

            if (proformaEntryDTO.Details != null && proformaEntryDTO.Details.Any())
            {
                foreach (var item in proformaEntryDTO.Details)
                {
                    await _detailsRepository.Add(new ProformaEntryDetail()
                    {
                        ProformaEntryId = result.Id,
                        FaisRefNo = item.FaisRefNo,
                        TranTypeSeq = item.TranTypeSeq,
                        CostCenter = item.CostCenter,
                        GlNo = item.GlNo,
                        RcaGl = item.RcaGl,
                        Prefix = item.Prefix,
                        Sl = item.Sl,
                        OtherCode = item.OtherCode,
                        Dce = item.Dce,
                        PlantCode = item.PlantCode,
                        Wo = item.Wo,
                        RefBillNo = item.RefBillNo,
                        Source = item.Source,
                        Nature = item.Nature,
                        AYyyy = item.AYyyy,
                        Fg = item.Fg,
                        Debit = item.Debit,
                        Credit = item.Credit,
                        TranDate = item.TranDate,
                        YmPosted = item.YmPosted,
                        Sort = item.Sort,
                        Udf1 = item.Udf1,
                        Udf2 = item.Udf2,
                        CreatedBy = result.CreatedBy,
                        CreatedAt = DateTime.Now
                    });
                }
            }

            return result;

            //var proformaEntry = _mapper.Map<ProformaEntry>(proformaEntryDTO);
            //proformaEntry.CreatedAt = DateTime.Now;
            //proformaEntry.StatusDate = DateTime.Now;

            //var result = await _repository.Add(proformaEntry);

            //var details = _mapper.Map<List<ProformaEntryDetail>>(proformaEntryDTO.ProformaEntryDetailsDTO);

            //if (details.Any())
            //{
            //    foreach (var detail in details)
            //    {
            //        detail.ProformaEntryId = result.Id;

            //        await _detailsRepository.Add(detail);
            //    }
            //}

            //return result;
        }

        public async Task<ProformaEntry> Update(ProformaEntryDTO proformaEntryDTO)
        {
            var proformaEntry = _repository.GetById(proformaEntryDTO.Id);
            
            proformaEntry.TranTypeSeq = proformaEntryDTO.TranTypeSeq;
            proformaEntry.Description = proformaEntryDTO.Description;
            proformaEntry.IsActive = proformaEntryDTO.IsActive;

            if (proformaEntry.IsActive != proformaEntryDTO.IsActive)
                proformaEntry.StatusDate = DateTime.Now;

            proformaEntry.UpdatedBy = proformaEntryDTO.UpdatedBy;
            proformaEntry.UpdatedAt = DateTime.Now;

           
            var result = await _repository.Update(proformaEntry);

            var proformaEntryDetails = _mapper.Map<List<ProformaEntryDetail>>(proformaEntryDTO.Details);

            if (result != null)
            {
                if (proformaEntryDetails.Any() && proformaEntryDetails.Count != proformaEntryDetails.Count)
                {
                    foreach (var detail in proformaEntryDetails.Where(t => !proformaEntryDetails.Select(a => a.Id).Contains(t.Id)))
                    {
                        if (detail.DeletedAt == null)
                        {
                            detail.DeletedAt = DateTime.Now;

                            await _detailsRepository.Update(detail);
                        }
                    }
                }

                if (proformaEntryDetails != null && proformaEntryDetails.Count > 0)
                {
                    foreach (var item in proformaEntryDetails)
                    {
                        if (item.Id > 0)
                        
                        await _detailsRepository.Update(item);
                        else
                        {
                            item.ProformaEntryId = result.Id;
                            await _detailsRepository.Add(item);
                        }
                    }
                }
            }

            return result;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}