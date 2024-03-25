using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAIS.Infrastructure.Data
{
    public class PlantInformationRepository : EFRepository<PlantInformation, int>, IPlantInformationRepository
    {
        public PlantInformationRepository(FAISContext context) : base(context)
        {
            
        }

        public IReadOnlyCollection<PlantInformationModel> Get()
        {
          
        }


    }
}
