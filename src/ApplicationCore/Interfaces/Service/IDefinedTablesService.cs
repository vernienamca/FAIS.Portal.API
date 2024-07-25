using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IDefinedTablesService
    {
        IReadOnlyCollection<DefinedTablesModel> Get();
        Task<DefinedTablesModel> GetById(int id);
        Task<DefinedTables> Add(DefinedTablesDTO dto);
        Task<DefinedTables> Update(DefinedTablesDTO dto);
    }
}
