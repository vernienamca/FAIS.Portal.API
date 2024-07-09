using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IDepreciationMethodsRepository
    {
        IReadOnlyCollection<DepreciationMethods> Get();
        Task<DepreciationMethods> GetById(int id);
        Task<DepreciationMethods> Add(DepreciationMethods dto);
        Task<DepreciationMethods> Update(DepreciationMethods dto);
    }
}
