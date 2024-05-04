using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FAIS.Infrastructure.Data
{
    public class CostCenterRepository : EFRepository<CostCenter, string>, ICostCenterRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CostCenterRepository"/> class.
        /// </summary>
        public CostCenterRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<CostCenterModel> Get()
        {
            var costCenters = (from t in _dbContext.CostCenters
                               select new CostCenterModel()
                               {
                                   FGCode = t.FGCode,
                                   MCNumber = t.MCNumber,
                                   LongName = t.LongName,
                                   ShortName = t.ShortName
                               }).ToList();

            return costCenters;
        }
    }
}
