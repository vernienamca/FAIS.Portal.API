using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class CostCenterRepository : EFRepository<CostCenter, int>, ICostCenterRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CostCenterRepository"/> class.
        /// </summary>
        public CostCenterRepository(FAISContext context) : base(context) { }

        public async Task<CostCenter> Add(CostCenter costCenter)
        {
            return await AddAsync(costCenter);
        }

        public IReadOnlyCollection<CostCenterModel> Get()
        {
            var costCenters = (from cc in _dbContext.CostCenters.AsNoTracking()
                               join usr in _dbContext.Users.AsNoTracking() on cc.CreatedBy equals usr.Id
                               orderby cc.Id descending
                               select new CostCenterModel()
                               {
                                   Id = cc.Id,
                                   Name = cc.Name,
                                   FGCode = cc.FGCode,
                                   Number = cc.Number,
                                   ShortName = cc.ShortName,
                                   CreatedBy = $"{usr.FirstName} {usr.LastName}",
                                   CreatedAt = cc.CreatedAt,
                               }).ToList();

            return costCenters;
        }

        public CostCenter GetById(int id)
        {
            return _dbContext.CostCenters.FirstOrDefault(t => t.Id == id);
        }

        public async Task<CostCenter> Update(CostCenter costCenter)
        {
            return await UpdateAsync(costCenter);
        }
    }
}
