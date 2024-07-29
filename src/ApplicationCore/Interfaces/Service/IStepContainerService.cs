using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IStepContainerService
    {
        IReadOnlyCollection<StepContainerModel> Get();
        Task<StepContainerModel> GetById(int id);
        Task<StepContainer> Add(StepContainerDTO dto);
        Task<StepContainer> Update(StepContainerDTO dto);
    }
}
