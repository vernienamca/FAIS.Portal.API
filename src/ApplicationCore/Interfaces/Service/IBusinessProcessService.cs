using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IBusinessProcessService
    {
        IReadOnlyCollection<BusinessProcessModel> Get();
        Task<BusinessProcessModel> GetById(int id);
        Task<BusinessProcess> Add(BusinessProcessDTO dto);
        Task<BusinessProcess> Update(BusinessProcessDTO dto);
    }
}
