using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class DefinedTablesRepository : EFRepository<DefinedTables, int>, IDefinedTablesRepository
    {
        public DefinedTablesRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<DefinedTablesModel> Get()
        {
            var ret = (from dt in _dbContext.DefinedTables.AsNoTracking()
                       join usr in _dbContext.Users.AsNoTracking() on dt.CreatedBy equals usr.Id
                       join usrU in _dbContext.Users.AsNoTracking() on dt.UpdatedBy equals usrU.Id into usrUX
                       from usrU in usrUX.DefaultIfEmpty()
                       orderby dt.Id descending
                       select new DefinedTablesModel()
                       {
                           Id = dt.Id,
                           BusinessProcessId = dt.BusinessProcessId,
                           TableName = dt.TableName,
                           IsActive = dt.IsActive,
                           StatusDate = dt.StatusDate,
                           CreatedBy = dt.CreatedBy,
                           CreatedAt = dt.CreatedAt,
                           UpdatedBy = dt.UpdatedBy,
                           UpdatedAt = dt.UpdatedAt,

                       }).ToList();
            return ret;
        }

        public async Task<DefinedTablesModel> GetById(int id)
        {
            var ret = (from dt in _dbContext.DefinedTables.AsNoTracking()
                       join usr in _dbContext.Users.AsNoTracking() on dt.CreatedBy equals usr.Id
                       join usrU in _dbContext.Users.AsNoTracking() on dt.UpdatedBy equals usrU.Id into usrUX
                       from usrU in usrUX.DefaultIfEmpty()
                       orderby dt.Id descending
                       select new DefinedTablesModel()
                       {
                           Id = dt.Id,
                           BusinessProcessId = dt.BusinessProcessId,
                           TableName = dt.TableName,
                           IsActive = dt.IsActive,
                           StatusDate = dt.StatusDate,
                           CreatedBy = dt.CreatedBy,
                           CreatedAt = dt.CreatedAt,
                           UpdatedBy = dt.UpdatedBy,
                           UpdatedAt = dt.UpdatedAt,

                       }).FirstOrDefaultAsync(t => t.Id == id);
            return await ret;
        }

        public async Task<DefinedTables> Add(DefinedTables dto)
        {
            return await AddAsync(dto);
        }

        public async Task<DefinedTables> Update(DefinedTables dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
