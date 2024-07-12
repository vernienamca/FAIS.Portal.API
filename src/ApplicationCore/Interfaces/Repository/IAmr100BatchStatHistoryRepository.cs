using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IAmr100BatchStatHistoryRepository
    {
        IReadOnlyCollection<Amr100BatchStatHistoryModel> Get();
        Task <IReadOnlyCollection<Amr100BatchStatHistoryModel>> GetById(int id);
        Task<Amr100BatchStatHistory> Add(Amr100BatchStatHistory amr);
        Task<Amr100BatchStatHistory> Update(Amr100BatchStatHistory amr);
    }
}
