using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class BusinessProcessRepository : EFRepository<BusinessProcess, int>, IBusinessProcessRepository
    {
        public BusinessProcessRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<BusinessProcessModel> Get()
        {
            var ret = (from bp in _dbContext.BusinessProcess.AsNoTracking()
                       join usr in _dbContext.Users.AsNoTracking() on bp.CreatedBy equals usr.Id
                       join usrU in _dbContext.Users.AsNoTracking() on bp.UpdatedBy equals usrU.Id into usrUX
                       from usrU in usrUX.DefaultIfEmpty()
                       orderby bp.Id descending
                       select new BusinessProcessModel()
                       {
                           Id = bp.Id,
                           BusinessProcessName = bp.BusinessProcessName,
                           Description = bp.Description,
                           IsActive = bp.IsActive,
                           StatusDate = bp.StatusDate,
                           CreatedAt = bp.CreatedAt,
                           UpdatedAt = bp.UpdatedAt,
                           CreatedBy = bp.CreatedBy,
                           UpdatedBy = bp.UpdatedBy,

                       }).ToList();
            return ret;
        }

        public async Task<BusinessProcessModel> GetById(int id)
        {
            var ret = (from bp in _dbContext.BusinessProcess.AsNoTracking()
                   join usr in _dbContext.Users.AsNoTracking() on bp.CreatedBy equals usr.Id
                   join usrU in _dbContext.Users.AsNoTracking() on bp.UpdatedBy equals usrU.Id into usrUX
                   from usrU in usrUX.DefaultIfEmpty()
                   orderby bp.Id descending
                   select new BusinessProcessModel()
                  {
                       Id = bp.Id,
                       BusinessProcessName = bp.BusinessProcessName,
                       Description = bp.Description,
                       IsActive = bp.IsActive,
                       StatusDate = bp.StatusDate,
                       CreatedAt = bp.CreatedAt,
                       UpdatedAt = bp.UpdatedAt,
                       CreatedBy = bp.CreatedBy,
                       UpdatedBy = bp.UpdatedBy,

                   }).FirstOrDefaultAsync(t => t.Id == id);
            return await ret;
        }

        public async Task<BusinessProcess> Add(BusinessProcess dto)
        {
            return await AddAsync(dto);
        }

        public async Task<BusinessProcess> Update(BusinessProcess dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
