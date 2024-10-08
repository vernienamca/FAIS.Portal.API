﻿using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IPlantInformationDetailsRepository
    {
        IReadOnlyCollection<PlantInformationDetailModel> Get();
        Task<PlantInformationDetailModel> GetById(int id);
        IReadOnlyCollection<PlantInformationDetails> GetByPlantCode(string plantCode);
        Task<PlantInformationDetails> Add(PlantInformationDetails dto);
        Task<PlantInformationDetails> Update(PlantInformationDetails dto);
        Task<PlantInformationDetails> GetDetails(int id);
    }
}
