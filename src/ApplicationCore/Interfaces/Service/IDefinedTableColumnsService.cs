using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IDefinedTableColumnsService
    {
        IReadOnlyCollection<DefinedTableColumnsModel> Get();
        Task<DefinedTableColumnsModel> GetById(int id);
        Task<DefinedTableColumns> Add(DefinedTableColumnsDTO dto);
        Task<DefinedTableColumns> Update(DefinedTableColumnsDTO dto);
    }
}
