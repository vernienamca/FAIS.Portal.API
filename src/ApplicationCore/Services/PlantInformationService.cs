using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAIS.ApplicationCore.Services
{
    public class PlantInformationService : IPlantInformationService
    {
        private readonly IPlantInformationRepository _repository;

        public PlantInformationService(IPlantInformationRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyCollection<PlantInformationModel> Get()
        {
            return _repository.Get();
        }
    }
}
