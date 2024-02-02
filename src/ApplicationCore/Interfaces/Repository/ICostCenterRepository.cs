using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface ICostCenterRepository
    {
        IReadOnlyCollection<CostCenterModel> Get();
        CostCenter GetById(int id);
        Task<CostCenter> Add(CostCenter costCenter);
        Task<CostCenter> Update(CostCenter costCenter);
    }
}
