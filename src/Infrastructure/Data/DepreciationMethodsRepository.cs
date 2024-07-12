using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class DepreciationMethodsRepository : EFRepository<DepreciationMethods, int>, IDepreciationMethodsRepository
    {
        public DepreciationMethodsRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<DepreciationMethodsModel> Get()
        {
            var ret = (from dm in _dbContext.DepreciationMethods.AsNoTracking()
                       join usr in _dbContext.Users.AsNoTracking() on dm.CreatedBy equals usr.Id
                       join usrU in _dbContext.Users.AsNoTracking() on dm.UpdatedBy equals usrU.Id into usrUX
                       from usrU in usrUX.DefaultIfEmpty()
                       orderby dm.Id descending
                       select new DepreciationMethodsModel()
                       {
                           Id = dm.Id,
                           Name = dm.Name,
                           Description = dm.Description,
                           StartDate = dm.StartDate,
                           EndDate = dm.EndDate,
                           BusinessProcessId = dm.BusinessProcessId,
                           IsSingleTransaction = dm.IsSingleTransaction,
                           FinalResultId = dm.FinalResultId,
                           IsActive = dm.IsActive,
                           StatusDate = dm.StatusDate,
                           CreatedAt = dm.CreatedAt,
                           UpdatedBy = dm.UpdatedBy,
                           UpdatedAt = dm.UpdatedAt,
                          
                       }).ToList();
            return ret;
        }

        public async Task<DepreciationMethodsModel> GetById(int id)
        {
            var ret = (from dm in _dbContext.DepreciationMethods.AsNoTracking()
                       join usr in _dbContext.Users.AsNoTracking() on dm.CreatedBy equals usr.Id
                       join usrU in _dbContext.Users.AsNoTracking() on dm.UpdatedBy equals usrU.Id into usrUX
                       from usrU in usrUX.DefaultIfEmpty()
                       orderby dm.Id descending
                       select new DepreciationMethodsModel()
                       {
                           Id = dm.Id,
                           Name = dm.Name,
                           Description = dm.Description,
                           StartDate = dm.StartDate,
                           EndDate = dm.EndDate,
                           BusinessProcessId = dm.BusinessProcessId,
                           IsSingleTransaction = dm.IsSingleTransaction,
                           FinalResultId = dm.FinalResultId,
                           IsActive = dm.IsActive,
                           StatusDate = dm.StatusDate,
                           CreatedAt = dm.CreatedAt,
                           UpdatedBy = dm.UpdatedBy,
                           UpdatedAt = dm.UpdatedAt,

                       }).FirstOrDefaultAsync(t => t.Id == id);
            return await ret;
        }

        public async Task<DepreciationMethods> Add(DepreciationMethods dto)
        {
            return await AddAsync(dto);
        }

        public async Task<DepreciationMethods> Update(DepreciationMethods dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
