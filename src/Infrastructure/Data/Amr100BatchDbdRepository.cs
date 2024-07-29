using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class Amr100BatchDbdRepository : EFRepository<Amr100BatchDbd, int>, IAmr100BatchDbdRepository
    {
        public Amr100BatchDbdRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<Amr100BatchDbdModel> Get(int amrBatchSeq, int reportSeq, string yearMonth)
        {
            var parts = yearMonth.Split('-');
            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);

            var amrs = (from amr in _dbContext.Amr100BatchDbd.AsNoTracking()
                            join amrD in _dbContext.Amr100BatchD.AsNoTracking() on amr.Amr100BatchDSeq equals amrD.Id
                            join amrB in _dbContext.Amr100Batch.AsNoTracking() on amrD.Amr100BatchSeq equals amrB.Id
                            join amrA in _dbContext.Amrs.AsNoTracking() on amrB.ReportSeq equals amrA.Id
                            join proj in _dbContext.ProjectProfile.AsNoTracking() on amrB.ProjectSeq equals proj.Id
                            join usr in _dbContext.Users.AsNoTracking() on amr.CreatedBy equals usr.Id
                            join usrU in _dbContext.Users.AsNoTracking() on amr.UpdatedBy equals usrU.Id into usrUX from usrU in usrUX.DefaultIfEmpty()
                            orderby amr.Id descending
                            select new Amr100BatchDbdModel()
                            {
                                Id = amr.Id,
                                ReportSeq = amrB.ReportSeq,
                                AmrYearMonth = amrA.AmrYm,
                                Amr100BatchSeq = amrD.Amr100BatchSeq,
                                Amr100BatchDSeq = amr.Amr100BatchDSeq,
                                AmrSeq = amr.AmrSeq,
                                NewAsset = amr.NewAsset,
                                ArSeq = amr.ArSeq,
                                AmrAssetSeq = amr.AmrAssetSeq,
                                WithIssues = amr.WithIssues,
                                AllocatedCost = amr.AllocatedCost,
                                Remarks = amr.Remarks,
                                NgcpAssetId = amr.NgcpAssetId,
                                TransactionDesc = amr.TransactionDesc,
                                TransactionDetails = amr.TransactionDetails,
                                LineSegment = amr.LineSegment,
                                UDF1 = amr.UDF1,
                                UDF2 = amr.UDF2,
                                UDF3 = amr.UDF3,
                                CreatedAt = amr.CreatedAt,
                                CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                UpdatedAt = amr.UpdatedAt,
                                CreatedBy = amr.CreatedBy,
                                UpdatedBy = amr.UpdatedBy,
                                UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",

                            })
                            .Where(x => x.ReportSeq == reportSeq && x.Amr100BatchSeq == amrBatchSeq && x.AmrYearMonth.Year == year && x.AmrYearMonth.Month == month)
                            .ToList();
            return amrs;
        }

        public async Task<Amr100BatchDbdModel> GetById(int id)
        {
            var amr = (from am in _dbContext.Amr100BatchDbd.AsNoTracking()
                           join usr in _dbContext.Users.AsNoTracking() on am.CreatedBy equals usr.Id
                           join usrU in _dbContext.Users.AsNoTracking() on am.UpdatedBy equals usrU.Id into usrUX
                           from usrU in usrUX.DefaultIfEmpty()
                           orderby am.Id descending
                           select new Amr100BatchDbdModel()
                           {
                               Id = am.Id,
                               Amr100BatchDSeq = am.Amr100BatchDSeq,
                               AmrSeq = am.AmrSeq,
                               NewAsset = am.NewAsset,
                               ArSeq = am.ArSeq,
                               AmrAssetSeq = am.AmrAssetSeq,
                               WithIssues = am.WithIssues,
                               AllocatedCost = am.AllocatedCost,
                               Remarks = am.Remarks,
                               NgcpAssetId = am.NgcpAssetId,
                               TransactionDesc = am.TransactionDesc,
                               TransactionDetails = am.TransactionDetails,
                               LineSegment = am.LineSegment,
                               UDF1 = am.UDF1,
                               UDF2 = am.UDF2,
                               UDF3 = am.UDF3,
                               CreatedAt = am.CreatedAt,
                               CreatedByName = $"{usr.FirstName} {usr.LastName}",
                               UpdatedAt = am.UpdatedAt,
                               CreatedBy = am.CreatedBy,
                               UpdatedBy = am.UpdatedBy,
                               UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",


                           }).FirstOrDefaultAsync(t => t.Id == id);
            return await amr;
        }
        public async Task<Amr100BatchDbd> Add(Amr100BatchDbd amr)
        {
            return await AddAsync(amr);
        }
        public async Task<Amr100BatchDbd> Update(Amr100BatchDbd amr)
        {
            return await UpdateAsync(amr);

        }
        public async Task BulkInsert(List<Amr100BatchDbd> amrs, BulkConfig bulkConfig)
        {
            await _dbContext.BulkInsertAsync(amrs, options =>
            {
                options.BatchSize = bulkConfig.BatchSize;
                options.BatchTimeout = bulkConfig.BulkCopyTimeout ?? 0;
            });
        }

        public async Task BulkUpdate(List<Amr100BatchDbd> amrs, BulkConfig bulkConfig)
        {
            await _dbContext.BulkUpdateAsync(amrs, options =>
            {
                options.BatchSize = bulkConfig.BatchSize;
                options.BatchTimeout = bulkConfig.BulkCopyTimeout ?? 0;
            });
        }

        public async Task BulkDelete(List<Amr100BatchDbd> amrs, BulkConfig bulkconfig)
        {
            await _dbContext.BulkDeleteAsync(amrs, options =>
            {
                options.BatchSize = bulkconfig.BatchSize;
                options.BatchTimeout = bulkconfig.BulkCopyTimeout ?? 0;
            });
        }
        public IQueryable<Amr100BatchDbd> GetAll()
        {
             return _dbContext.Amr100BatchDbd;
        }
    }
}
