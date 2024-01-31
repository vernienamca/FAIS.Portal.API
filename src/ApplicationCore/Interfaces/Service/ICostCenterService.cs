using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Services
{
    public interface ICostCenterService
    {
        IReadOnlyCollection<CostCenterModel> Get();
        CostCenter GetById(int id);
        Task<CostCenter> Add(CostCenterDTO costCenterDTO);
        Task<CostCenter> Update(CostCenterDTO costCenterDTO);
    }
}
