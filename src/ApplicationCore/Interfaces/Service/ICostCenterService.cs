using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.Interfaces.Services
{
    public interface ICostCenterService
    {
        IReadOnlyCollection<CostCenterModel> Get();
    }
}
