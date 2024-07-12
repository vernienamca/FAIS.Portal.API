using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class Amr100BatchStatHistoryRepository : EFRepository<Amr100BatchStatHistory, int>, IAmr100BatchStatHistoryRepository
    {
        public Amr100BatchStatHistoryRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<Amr100BatchStatHistoryModel> Get()
        {
            var amrs = (from amr in _dbContext.Amr100BatchStatHistory.AsNoTracking()
                                join usr in _dbContext.Users.AsNoTracking() on amr.CreatedBy equals usr.Id
                                orderby amr.Id descending
                                select new Amr100BatchStatHistoryModel()
                                {
                                    Id = amr.Id,
                                    Amr100BatchSeq = amr.Amr100BatchSeq,    
                                    StatusCodeLto = amr.StatusCodeLto,
                                    StatusDate = amr.StatusDate,
                                    StatusRemarks = amr.StatusRemarks,
                                    CreatedBy = amr.CreatedBy,
                                    UserName = usr.UserName
                                }).ToList();
            return amrs;
        }

        public async Task<IReadOnlyCollection<Amr100BatchStatHistoryModel>> GetById(int id)
        {
            var amr = (from am in _dbContext.Amr100BatchStatHistory.AsNoTracking()
                                join usr in _dbContext.Users.AsNoTracking() on am.CreatedBy equals usr.Id
                                where am.Amr100BatchSeq == id
                                orderby am.Id descending
                                select new Amr100BatchStatHistoryModel()
                                {
                                    Id = am.Id,
                                    Amr100BatchSeq = am.Amr100BatchSeq,               
                                    StatusCodeLto = am.StatusCodeLto,
                                    StatusDate = am.StatusDate,
                                    StatusRemarks = am.StatusRemarks,
                                    CreatedBy = am.CreatedBy
                                }).ToListAsync();
            return await amr;
        }

        public async Task<Amr100BatchStatHistory> Add(Amr100BatchStatHistory amr)
        {
            return await AddAsync(amr);
        }

        public async Task<Amr100BatchStatHistory> Update(Amr100BatchStatHistory amr)
        {
            return await UpdateAsync(amr);
        }
    }
}
