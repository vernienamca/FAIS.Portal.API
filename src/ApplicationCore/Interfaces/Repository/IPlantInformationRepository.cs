using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IPlantInformationRepository
    {
        IReadOnlyCollection<PlantInformationModel> Get();
        PlantInformationModel GetById(string plantCode);
        Task<PlantInformation> Add(PlantInformation dto);
        Task<PlantInformation> Update(PlantInformation dto);
    }
}
