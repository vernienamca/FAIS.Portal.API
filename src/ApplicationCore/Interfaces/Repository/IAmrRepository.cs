using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IAmrRepository
    {
        IReadOnlyCollection<AmrModel> Get();
        Task<AmrModel> GetById(int id);
        Task<Amr> GetByIdForEncoding(int id);
        Task<Amr> Add(Amr amr);
        Task<Amr> Update(Amr amr);
    }
}
