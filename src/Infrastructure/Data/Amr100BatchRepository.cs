using DocumentFormat.OpenXml.Wordprocessing;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class Amr100BatchRepository : EFRepository<Amr100Batch, int>, IAmr100BatchRepository
    {
        public Amr100BatchRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<Amr100BatchModel> Get(int reportSeqId, string yearMonth)
        {
            var parts = yearMonth.Split('-');
            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);

            var amrs = (from amr in _dbContext.Amr100Batch.AsNoTracking()
                                join amrD in _dbContext.Amr100BatchD.AsNoTracking() on amr.Id equals amrD.Amr100BatchSeq into amrDx
                                from amrD in amrDx.DefaultIfEmpty()
                                join amrA in _dbContext.Amrs.AsNoTracking() on amr.ReportSeq equals amrA.Id
                                join proj in _dbContext.ProjectProfile.AsNoTracking() on amr.ProjectSeq equals proj.Id
                                join usr in _dbContext.Users.AsNoTracking() on amr.CreatedBy equals usr.Id
                                join usrU in _dbContext.Users.AsNoTracking() on amr.UpdatedBy equals usrU.Id into usrUX from usrU in usrUX.DefaultIfEmpty()
                                orderby amr.Id descending
                                select new Amr100BatchModel()
                                {
                                    Id = amr.Id, 
                                    AmrYearMonth = amrA.AmrYm,
                                    ReportSeq = amr.ReportSeq,
                                    ReportFgLto = amr.ReportFgLto,
                                    ProjectSeq = amr.ProjectSeq,
                                    ProjectName = proj.ProjectName,
                                    ProjectComponentLto = amr.ProjectComponentLto,
                                    Remarks = amr.Remarks,
                                    UDF1 = amr.UDF1,
                                    UDF2 = amr.UDF2,
                                    UDF3 = amr.UDF3,
                                    StatusCode = amr.StatusCode,
                                    StatusDate = amr.StatusDate,
                                    AccStatusDate = amr.AccStatusDate,
                                    AssignedTo = amr.AssignedTo,
                                    CreatedAt = amr.CreatedAt,
                                    CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                    UpdatedAt = amr.UpdatedAt,
                                    CreatedBy = amr.CreatedBy,
                                    UpdatedBy = amr.UpdatedBy,
                                    UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                    TotalReport = amr.TotalReport,
                                    TotalAmrIssues = _dbContext.Amr100BatchDbd.AsNoTracking().Count(dbd => dbd.Amr100BatchDSeq == amrD.Id && dbd.WithIssues == 'Y')

                                })
                                .Where(x => x.ReportSeq == reportSeqId && x.AmrYearMonth.Year == year && x.AmrYearMonth.Month == month)
                                .ToList();

            var groupedAmrs = amrs.GroupBy(x => x.Id).Select(g =>
            {
                var first = g.First();
                first.TotalAmrIssues = g.Sum(x => x.TotalAmrIssues);
                return first;
            }).ToList();

            return amrs;
        }

        public async Task<Amr100BatchModel> GetById(int id)
        {
            var amr = (from am in _dbContext.Amr100Batch.AsNoTracking()
                                join amrA in _dbContext.Amrs.AsNoTracking() on am.ReportSeq equals amrA.Id
                                join usr in _dbContext.Users.AsNoTracking() on am.CreatedBy equals usr.Id
                                join usrU in _dbContext.Users.AsNoTracking() on am.UpdatedBy equals usrU.Id into usrUX
                                from usrU in usrUX.DefaultIfEmpty()
                                orderby am.Id descending
                                select new Amr100BatchModel()
                                {
                                    Id = am.Id,
                                    ReportSeq = am.ReportSeq,
                                    AmrYearMonth = amrA.AmrYm,
                                    ReportFgLto = am.ReportFgLto,
                                    ProjectSeq = am.ProjectSeq,
                                    ProjectComponentLto = am.ProjectComponentLto,
                                    Remarks = am.Remarks,
                                    UDF1 = am.UDF1,
                                    UDF2 = am.UDF2,
                                    UDF3 = am.UDF3,
                                    StatusCode = am.StatusCode,
                                    StatusDate = am.StatusDate,
                                    AccStatusDate = am.AccStatusDate,
                                    AssignedTo = am.AssignedTo,
                                    CreatedAt = am.CreatedAt,
                                    UpdatedAt = am.UpdatedAt,
                                    CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                    UpdatedBy = am.UpdatedBy,
                                    UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                    TotalReport = am.TotalReport,

                                }).FirstOrDefaultAsync(t => t.Id == id);
            return await amr;
        }

        public async Task<Amr100Batch> Add(Amr100Batch amr)
        {
            return await AddAsync(amr);
        }

        public async Task<Amr100Batch> Update(Amr100Batch amr)
        {
            return await UpdateAsync(amr);
        }
    }
}
