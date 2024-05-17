using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class PlantInformationService : IPlantInformationService
    {
        private readonly IPlantInformationRepository _repository;
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
            var piDto = _mapper.Map<PlantInformation>(dto);
            return await _repository.Add(piDto);
        }

        public async Task<PlantInformation> Update(UpdatePlantInformationDTO dto)
        {
            var pi = _repository.GetByCode(dto.PlantCode) ?? throw new Exception("Plant Code does not exist");

            if (pi == null)
                throw new ArgumentNullException("Plant Information does not exist.");

            var mapper = _mapper.Map<PlantInformation>(dto);
            mapper.CreatedBy = pi.Result.CreatedBy;
            mapper.CreatedAt = pi.Result.CreatedAt;
            return await _repository.Update(mapper);
        }
    }
}
