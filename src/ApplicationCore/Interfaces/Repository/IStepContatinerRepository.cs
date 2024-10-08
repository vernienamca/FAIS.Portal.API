﻿using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IStepContatinerRepository
    {
        IReadOnlyCollection<StepContainerModel> Get();
        Task<StepContainerModel> GetById(int id);
        Task<StepContainer> Add(StepContainer dto);
        Task<StepContainer> Update(StepContainer dto);
    }
}
