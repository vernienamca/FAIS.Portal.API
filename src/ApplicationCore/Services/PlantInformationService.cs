using AutoMapper;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
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

        public PlantInformationService(IPlantInformationRepository repository, IPlantInformationDetailsRepository detailsRepository, IMapper mapper)
        {
            _repository = repository;
            _detailsRepository = detailsRepository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<PlantInformationModel> Get()
        {
            return _repository.Get();
        }

        public PlantInformationModel GetById(string id)
        {
            return _repository.GetById(id);
        }

        public async Task<PlantInformation> Add(AddPlantInformationDTO plantInfoDTO)
        {
            PlantInformation plantInfo = new PlantInformation()
            {
                PlantCode = plantInfoDTO.PlantCode,
                SubstationName = plantInfoDTO.SubstationName,
                SubstationNameOld = plantInfoDTO.SubstationNameOld,
                ClassId = plantInfoDTO.ClassId,
                TransGrid = plantInfoDTO.TransGrid,
                DistrictId = plantInfoDTO.DistrictId,
                MtdId = plantInfoDTO.MtdId,
                GmapCoord = plantInfoDTO.GmapCoord,
                RegionId = plantInfoDTO.RegionId,
                ProvId = plantInfoDTO.ProvId,
                MunId = plantInfoDTO.MunId,
                BrgyId = plantInfoDTO.BrgyId,
                IsActive = plantInfoDTO.IsActive,
                StatusDate = DateTime.Now,
                UDF1 = plantInfoDTO.UDF1,
                UDF2 = plantInfoDTO.UDF2,
                UDF3 = plantInfoDTO.UDF3,
                CommissionDate = plantInfoDTO.CommissionDate,
                CreatedBy = plantInfoDTO.CreatedBy,
                CreatedAt = DateTime.Now
            };

            var result = await _repository.Add(plantInfo);

            if (plantInfoDTO.Details != null && plantInfoDTO.Details.Any())
            {
                foreach (var item in plantInfoDTO.Details)
                {
                    await _detailsRepository.Add(new PlantInformationDetails()
                    {
                        PlantCode = item.PlantCode,
                        CostCenter = item.CostCenterType.Value,
                        CreatedBy = result.CreatedBy,
                        CreatedAt = item.CreatedAt,
                        CostCenterNo = item.CostCenterNo
                    });
                }
            }

            return result;
        }

        public async Task<PlantInformation> Update(UpdatePlantInformationDTO plantInfoDTO)
        {
            if (plantInfoDTO == null)
                throw new ArgumentNullException(nameof(plantInfoDTO));

            var plantInfo = _repository.GetById(plantInfoDTO.PlantCode);

            if (plantInfoDTO.IsActive != plantInfo.IsActive)
            {
                plantInfo.IsActive = plantInfoDTO.IsActive;
                plantInfo.StatusDate = DateTime.Now;
            }

            var mapper = _mapper.Map<PlantInformation>(plantInfoDTO);
            mapper.CreatedBy = plantInfo.CreatedBy;
            mapper.CreatedAt = plantInfo.CreatedAt;

            var result = await _repository.Update(mapper);

            if (plantInfoDTO.Details != null && plantInfoDTO.Details.Any())
            {
                int[] detailUniqueIds = plantInfoDTO.Details.Select(s => s.Id.Value).ToArray();
                var detailsToRemove = _detailsRepository.GetByPlantCode(result.PlantCode).Where(t => detailUniqueIds.Any(a => t.Id != a));

                foreach (var item in detailsToRemove)
                {
                    var detail = await _detailsRepository.GetDetails(item.Id);
                    
                    detail.RemovedAt = DateTime.Now;
                    await _detailsRepository.Update(detail);
                }

                foreach (var item in plantInfoDTO.Details)
                {
                    if (item.Id.HasValue)
                    {
                        var detail = await _detailsRepository.GetDetails(item.Id.Value);

                        if (detail.CostCenter != item.CostCenterType || detail.CostCenterNo != item.CostCenterNo)
                        {
                            detail.CostCenter = item.CostCenterType.Value;
                            detail.CostCenterNo = item.CostCenterNo;
                            detail.UpdatedBy = result.UpdatedBy;
                            detail.UpdatedAt = DateTime.Now;
                            await _detailsRepository.Update(detail);
                        }
                    } 
                    else
                    {
                        await _detailsRepository.Add(new PlantInformationDetails()
                        {
                            PlantCode = item.PlantCode,
                            CostCenter = item.CostCenterType.Value,
                            CreatedBy = result.CreatedBy,
                            CreatedAt = item.CreatedAt,
                            CostCenterNo = item.CostCenterNo
                        });
                    }
                }
            }

            return result;
        }

        #region Private



        #endregion Private
    }
}
