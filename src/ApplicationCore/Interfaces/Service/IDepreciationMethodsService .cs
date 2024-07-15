using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IDepreciationMethodsService
    {
        IReadOnlyCollection<DepreciationMethodsModel> Get();
        Task<DepreciationMethodsModel> GetById(int id);
        Task<DepreciationMethods> Add(DepreciationMethodsDTO dto);
        Task<DepreciationMethods> Update(DepreciationMethodsDTO dto);
    }
}
