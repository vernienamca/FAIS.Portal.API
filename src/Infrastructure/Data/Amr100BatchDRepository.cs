using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class Amr100BatchDRepository : EFRepository<Amr100BatchD, int>, IAmr100BatchDRepository
    {
        public Amr100BatchDRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<Amr100BatchDModel> Get(int amrBatchSeq, int reportSeq, string yearMonth)
        {
            var parts = yearMonth.Split('-');
            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);

            var amrs = (from amr in _dbContext.Amr100BatchD.AsNoTracking()
                                join am in _dbContext.Amr100Batch.AsNoTracking() on amr.Amr100BatchSeq equals am.Id
                                join amrA in _dbContext.Amrs.AsNoTracking() on am.ReportSeq equals amrA.Id
                                join proj in _dbContext.ProjectProfile.AsNoTracking() on am.ProjectSeq equals proj.Id
                                join usr in _dbContext.Users.AsNoTracking() on amr.CreatedBy equals usr.Id
                                join usrU in _dbContext.Users.AsNoTracking() on amr.UpdatedBy equals usrU.Id into usrUX from usrU in usrUX.DefaultIfEmpty()
                                orderby amr.Id descending
                                select new Amr100BatchDModel()
                                {
                                    Id = amr.Id,
                                    ReportSeq = am.ReportSeq,
                                    AmrYearMonth = amrA.AmrYm,
                                    Amr100BatchSeq = amr.Amr100BatchSeq,
                                    ReportFg = am.ReportFgLto,
                                    ProjectName = proj.ProjectName,
                                    RoaSeq = amr.RoaSeq,
                                    FgLto = amr.FgLto,
                                    AmrLocation = amr.AmrLocation,
                                    AmrWbsNo = amr.AmrWbsNo,
                                    AmrAssetNo = amr.AmrAssetNo,
                                    AmrAsset = amr.AmrAsset,
                                    AmrProjectName = amr.AmrProjectName,
                                    AmrEconomicLife = amr.AmrEconomicLife,
                                    AmrCost = amr.AmrCost,
                                    AmrCompletionDate = amr.AmrCompletionDate,
                                    AmrAssetClass = amr.AmrAssetClass,
                                    AmrReferenceNo = amr.AmrReferenceNo,
                                    Qty = amr.Qty,
                                    UDF1 = amr.UDF1,
                                    UDF2 = amr.UDF2,
                                    UDF3 = amr.UDF3,
                                    IsReturnedToEncoder = amr.IsReturnedToEncoder,
                                    IsReturnedToAnalysis = amr.IsReturnedToAnalysis,
                                    ProformaEntrySeq = amr.ProformaEntrySeq,
                                    Remarks = amr.Remarks,
                                    StatusCodeLto = amr.StatusCodeLto,
                                    StatusDate = amr.StatusDate,
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

        public async Task<Amr100BatchDModel> GetById(int id)
        {
            var amr = (from am in _dbContext.Amr100BatchD.AsNoTracking()
                                join usr in _dbContext.Users.AsNoTracking() on am.CreatedBy equals usr.Id
                                join usrU in _dbContext.Users.AsNoTracking() on am.UpdatedBy equals usrU.Id into usrUX
                                from usrU in usrUX.DefaultIfEmpty()
                                orderby am.Id descending
                                select new Amr100BatchDModel()
                                {
                                    Id = am.Id,
                                    Amr100BatchSeq = am.Amr100BatchSeq,
                                    RoaSeq = am.RoaSeq,
                                    FgLto = am.FgLto,
                                    AmrLocation = am.AmrLocation,
                                    AmrWbsNo = am.AmrWbsNo,
                                    AmrAssetNo = am.AmrAssetNo,
                                    AmrAsset = am.AmrAsset,
                                    AmrProjectName = am.AmrProjectName,
                                    AmrEconomicLife = am.AmrEconomicLife,
                                    AmrCost = am.AmrCost,
                                    AmrCompletionDate = am.AmrCompletionDate,
                                    AmrAssetClass = am.AmrAssetClass,
                                    AmrReferenceNo = am.AmrReferenceNo,
                                    Qty = am.Qty,
                                    UDF1 = am.UDF1,
                                    UDF2 = am.UDF2,
                                    UDF3 = am.UDF3,
                                    IsReturnedToEncoder = am.IsReturnedToEncoder,
                                    IsReturnedToAnalysis = am.IsReturnedToAnalysis,
                                    ProformaEntrySeq = am.ProformaEntrySeq,
                                    Remarks = am.Remarks,
                                    StatusCodeLto = am.StatusCodeLto,
                                    StatusDate = am.StatusDate,
                                    CreatedAt = am.CreatedAt,
                                    CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                    UpdatedAt = am.UpdatedAt,
                                    CreatedBy = am.CreatedBy,
                                    UpdatedBy = am.UpdatedBy,
                                    UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                 
                                }).FirstOrDefaultAsync(t => t.Id == id);
            return await amr;
        }

        public async Task<Amr100BatchD> Add(Amr100BatchD amr)
        {
            return await AddAsync(amr);
        }

        public async Task<Amr100BatchD> Update(Amr100BatchD amr)
        {
            return await UpdateAsync(amr);
        }

        public async Task BulkUpdate(List<Amr100BatchD> amrs)
        {
            await BulkUpdateAsync(amrs);
        }

        public  IQueryable <Amr100BatchD> GetAll()
        {
            return _dbContext.Amr100BatchD;
        }

        public async Task<Amr100BatchD> GetBatchDById(int id)
        {
            return await _dbContext.Amr100BatchD.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
