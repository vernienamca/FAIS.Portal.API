using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IPlantInformationService
    {
        IReadOnlyCollection<PlantInformationModel> Get();
        PlantInformationModel GetById(string id);
        Task<PlantInformation> Add(AddPlantInformationDTO plantInfoDTO);
        Task<PlantInformation> Update(UpdatePlantInformationDTO plantInfoDTO);
    }
}
