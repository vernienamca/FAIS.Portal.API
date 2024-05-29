using AutoMapper;
using FAIS.ApplicationCore.BusinessRules;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.DTOs.Structure;
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

        public async Task<ProformaEntry> Add(ProformaEntryDTO proformaEntryDTO)
        {
            var proformaEntry = _mapper.Map<ProformaEntry>(proformaEntryDTO);
            var proformaEntryDetails = _mapper.Map<List<ProformaEntryDetail>>(proformaEntryDTO.ProformaEntryDetailsDTO);

            var proformaEntryResult = await _repository.Add(proformaEntry);

            //Check proforma entry details
            if (proformaEntryDetails != null)
            {
                foreach (var detail in proformaEntryDetails)
                {
                    detail.ProformaEntryId = proformaEntryResult.Id;
                    await _detailsRepository.Add(detail);
                }
            }
            return proformaEntryResult;
        }

        public async Task<ProformaEntry> Update(ProformaEntryDTO proformaEntryDTO)
        {
            var proformaEntry = _mapper.Map<ProformaEntry>(proformaEntryDTO);
            var proformaEntryDetails = _mapper.Map<List<ProformaEntryDetail>>(proformaEntryDTO.ProformaEntryDetailsDTO);

            var proformaEntryResult = await _repository.Update(proformaEntry);

            if (proformaEntryResult != null)
            {
                var details = _detailsRepository.GetById(proformaEntry.Id);
                if (details != null)
                {
                    if (details.Count > 0 && details.Count != proformaEntryDetails.Count)
                    {
                        foreach (var detail in details.Where(o => !proformaEntryDetails.Select(a => a.Id).Contains(o.Id)))
                        {
                            if (detail.DeletedAt == null)
                            {
                                detail.DeletedAt = DateTime.Now;
                                await _detailsRepository.Update(detail);
                            }
                        }
                    }
                }

                if (proformaEntryDetails != null && proformaEntryDetails.Count > 0)
                {
                    foreach (var item in proformaEntryDetails)
                    {
                        if (item.Id > 0)
                        {
                            await _detailsRepository.Update(item);
                        }
                        else
                        {
                            item.ProformaEntryId = proformaEntryResult.Id;
                            await _detailsRepository.Add(item);
                        }
                    }
                }
            }
            return proformaEntryResult;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}