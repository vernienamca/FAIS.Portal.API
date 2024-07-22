using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IAmr100BatchDbdRepository
    {
        IReadOnlyCollection<Amr100BatchDbdModel> Get();
        Task<Amr100BatchDbdModel> GetById(int id);
        Task<Amr100BatchDbd> Add(Amr100BatchDbd amr);
        Task<Amr100BatchDbd> Update(Amr100BatchDbd amr);
        Task BulkInsert(List<Amr100BatchDbd> amrs, BulkConfig bulkconfig);
        Task BulkDelete(List<Amr100BatchDbd> amr , BulkConfig bulkconfig);
        IQueryable<Amr100BatchDbd> GetAll();
    }
}
