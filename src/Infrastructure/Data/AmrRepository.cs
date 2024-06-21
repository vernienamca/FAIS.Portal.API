using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class AmrRepository : EFRepository<Amr, int>, IAmrRepository
    {
        public AmrRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<AmrModel> Get()
        {
            var amrs = (from amr in _dbContext.Amrs.AsNoTracking()
                                join usr in _dbContext.Users.AsNoTracking() on amr.CreatedBy equals usr.Id
                                join usrU in _dbContext.Users.AsNoTracking() on amr.UpdatedBy equals usrU.Id into usrUX from usrU in usrUX.DefaultIfEmpty()
                                orderby amr.Id descending
                                select new AmrModel()
                                {
                                    Id = amr.Id,
                                    AmrYm = amr.AmrYm,
                                    DateReceivedTransco = amr.DateReceivedTransco,
                                    DateReceivedArmPmd = amr.DateReceivedArmPmd,
                                    DateSentEncoding = amr.DateSentEncoding,
                                    NoOfBinders = amr.NoOfBinders,
                                    UDF1 = amr.UDF1,
                                    UDF2 = amr.UDF2,
                                    UDF3 = amr.UDF3,
                                    CreatedBy = amr.CreatedBy,
                                    CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                    CreatedAt = amr.CreatedAt,
                                    UpdatedBy = amr.UpdatedBy,
                                    UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                    UpdatedAt = amr.UpdatedAt
                                }).ToList();
            return amrs;
        }

        public async Task<AmrModel> GetById(int id)
        {
            var amr = (from am in _dbContext.Amrs.AsNoTracking()
                                join usr in _dbContext.Users.AsNoTracking() on am.CreatedBy equals usr.Id
                                join usrU in _dbContext.Users.AsNoTracking() on am.UpdatedBy equals usrU.Id into usrUX
                                from usrU in usrUX.DefaultIfEmpty()
                                orderby am.Id descending
                                select new AmrModel()
                                {
                                    Id = am.Id,
                                    AmrYm = am.AmrYm,
                                    DateReceivedTransco = am.DateReceivedTransco,
                                    DateReceivedArmPmd = am.DateReceivedArmPmd,
                                    DateSentEncoding = am.DateSentEncoding,
                                    NoOfBinders = am.NoOfBinders,
                                    UDF1 = am.UDF1,
                                    UDF2 = am.UDF2,
                                    UDF3 = am.UDF3,
                                    CreatedBy = am.CreatedBy,
                                    CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                    CreatedAt = am.CreatedAt,
                                    UpdatedBy = am.UpdatedBy,
                                    UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                    UpdatedAt = am.UpdatedAt
                                }).FirstOrDefaultAsync(t => t.Id == id);
            return await amr;
        }

        public async Task<Amr> GetByIdForEncoding(int id)
        {
            return await _dbContext.Amrs.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Amr> Add(Amr amr)
        {
            return await AddAsync(amr);
        }

        public async Task<Amr> Update(Amr amr)
        {
            return await UpdateAsync(amr);
        }
    }
}
