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
        PlantInformationModel GetByCode(string plantCode);
        Task<PlantInformation> Add(AddPlantInformationDTO dto);
        Task<PlantInformation> Update(UpdatePlantInformationDTO dto);
    }
}
