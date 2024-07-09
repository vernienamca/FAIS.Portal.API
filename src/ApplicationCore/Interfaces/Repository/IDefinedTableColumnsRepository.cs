using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IDefinedTableColumnsRepository
    {
        IReadOnlyCollection<DefinedTableColumns> Get();
        Task<DefinedTableColumns> GetById(int id);
        Task<DefinedTableColumns> Add(DefinedTableColumns dto);
        Task<DefinedTableColumns> Update(DefinedTableColumns dto);
    }
}
