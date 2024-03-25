using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAIS.ApplicationCore.Interfaces
{
    public class IPlantInformationRepository
    {
        IReadOnlyCollection<PlantInformationModel> Get();

    }
}
