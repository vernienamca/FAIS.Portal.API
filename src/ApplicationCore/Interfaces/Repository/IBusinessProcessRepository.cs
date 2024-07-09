using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IBusinessProcessRepository
    {
        IReadOnlyCollection<BusinessProcess> Get();
        Task<BusinessProcess> GetById(int id);
        Task<BusinessProcess> Add(BusinessProcess dto);
        Task<BusinessProcess> Update(BusinessProcess dto);
    }
}
