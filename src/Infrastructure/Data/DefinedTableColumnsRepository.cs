using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class DefinedTableColumnsRepository : EFRepository<DefinedTableColumns, int>, IDefinedTableColumnsRepository
    {
        public DefinedTableColumnsRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<DefinedTableColumnsModel> Get()
        {
            var ret = (from dtc in _dbContext.DefinedTableColumns.AsNoTracking()
                       join usr in _dbContext.Users.AsNoTracking() on dtc.CreatedBy equals usr.Id
                       join usrU in _dbContext.Users.AsNoTracking() on dtc.UpdatedBy equals usrU.Id into usrUX
                       from usrU in usrUX.DefaultIfEmpty()
                       orderby dtc.Id descending
                       select new DefinedTableColumnsModel()
                       {
                           Id = dtc.Id,
                           DefinedTableId = dtc.DefinedTableId,
                           ColumnName = dtc.ColumnName,
                           IsActive = dtc.IsActive,
                           StatusDate = dtc.StatusDate,
                           CreatedBy = dtc.CreatedBy,
                           CreatedAt = dtc.CreatedAt,
                           UpdatedBy = dtc.UpdatedBy,
                           UpdatedAt = dtc.UpdatedAt,

                       }).ToList();
            return ret;
        }

        public async Task<DefinedTableColumnsModel> GetById(int id)
        {
            var ret = (from dtc in _dbContext.DefinedTableColumns.AsNoTracking()
                       join usr in _dbContext.Users.AsNoTracking() on dtc.CreatedBy equals usr.Id
                       join usrU in _dbContext.Users.AsNoTracking() on dtc.UpdatedBy equals usrU.Id into usrUX
                       from usrU in usrUX.DefaultIfEmpty()
                       orderby dtc.Id descending
                       select new DefinedTableColumnsModel()
                       {
                           Id = dtc.Id,
                           DefinedTableId = dtc.DefinedTableId,
                           ColumnName = dtc.ColumnName,
                           IsActive = dtc.IsActive,
                           StatusDate = dtc.StatusDate,
                           CreatedBy = dtc.CreatedBy,
                           CreatedAt = dtc.CreatedAt,
                           UpdatedBy = dtc.UpdatedBy,
                           UpdatedAt = dtc.UpdatedAt,

                       }).FirstOrDefaultAsync(t => t.Id == id);
            return await ret;
        }

        public async Task<DefinedTableColumns> Add(DefinedTableColumns dto)
        {
            return await AddAsync(dto);
        }

        public async Task<DefinedTableColumns> Update(DefinedTableColumns dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
