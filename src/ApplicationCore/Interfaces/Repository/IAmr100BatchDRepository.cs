using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IAmr100BatchDRepository
    {
        IReadOnlyCollection<Amr100BatchDModel> Get(int amrBatchSeq, int reportSeq, string yearMonth);
        Task<Amr100BatchDModel> GetById(int id);
        Task<Amr100BatchD> Add(Amr100BatchD amr);
        Task<Amr100BatchD> Update(Amr100BatchD amr);
        IQueryable <Amr100BatchD> GetAll();
        Task Update(List<Amr100BatchD> amrs);
        Task BulkUpdateIgnoreQuantity(List<Amr100BatchD> amrs);
    }
}
