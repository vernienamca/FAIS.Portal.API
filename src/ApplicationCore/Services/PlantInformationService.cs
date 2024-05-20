using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class PlantInformationService : IPlantInformationService
    {
        private readonly IPlantInformationRepository _repository;
        private readonly IPlantInformationDetailsRepository _detailsRepository;
        private readonly IMapper _mapper;

        public PlantInformationService(IPlantInformationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<PlantInformationModel> Get()
        {
            return _repository.Get();
        }

        public async Task<PlantInformationModel> GetByCode(string plantCode)
        {
            return await _repository.GetByCode(plantCode);
        }

        public async Task<PlantInformation> Add(AddPlantInformationDTO dto)
        {
            var pi = _mapper.Map<PlantInformation>(dto);
            var piDetail = _mapper.Map<List<PlantInformationDetails>>(dto.PlantInformationDetailDTO);

            var piResult = await _repository.Add(pi);

            if (piDetail != null)
            {
                foreach (var detail in piDetail)
                {
                    detail.PlantCode = piResult.PlantCode;
                    await _detailsRepository.Add(detail);
                }
            }
            return piResult;
        }

        public async Task<PlantInformation> Update(UpdatePlantInformationDTO dto)
        {
            var pi = _repository.GetByCode(dto.PlantCode) ?? throw new Exception("Plant Code does not exist");
            var piDetail = _mapper.Map<List<PlantInformationDetails>>(dto.PlantInformationDetailDTO);

            if (pi == null)
                throw new ArgumentNullException("Plant Information does not exist.");

            var mapper = _mapper.Map<PlantInformation>(dto);
            mapper.CreatedBy = pi.Result.CreatedBy;
            mapper.CreatedAt = pi.Result.CreatedAt;

            var piResult = await _repository.Update(mapper);

            if (piResult != null)
            {
                var details = _detailsRepository.GetByCode(mapper.PlantCode);
                if (details != null)
                {
                    if (details.Count > 0 && details.Count != piDetail.Count)
                    {
                        foreach (var detail in details.Where(o => !piDetail.Select(a => a.Id).Contains(o.Id)))
                        {
                            if (detail.RemovedAt == null)
                            {
                                detail.RemovedAt = DateTime.Now;
                                await _detailsRepository.Update(detail);
                            }
                        }
                    }
                }

                if (piDetail != null && piDetail.Count > 0)
                {
                    foreach (var item in piDetail)
                    {
                        if (item.Id > 0)
                        {
                            await _detailsRepository.Update(item);
                        }
                        else
                        {
                            item.PlantCode = piResult.PlantCode;
                            await _detailsRepository.Add(item);
                        }
                    }
                }
            }
            return piResult;
        }
    }
}
