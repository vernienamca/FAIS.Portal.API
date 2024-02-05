using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class ChartOfAccountsRepository : EFRepository<ChartOfAccounts, int>, IChartOfAccountsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChartOfAccountsRepository"/> class.
        /// </summary>
        public ChartOfAccountsRepository(FAISContext context) : base(context) { }

        public async Task<ChartOfAccounts> Add(ChartOfAccounts chartOfAccounts)
        {
            return await AddAsync(chartOfAccounts);
        }

        public IReadOnlyCollection<ChartOfAccountModel> Get()
        {
            var chartOfAccounts = (from ca in _dbContext.ChartOfAccounts.AsNoTracking()
                               join usr in _dbContext.Users.AsNoTracking() on ca.CreatedBy equals usr.Id
                               orderby ca.Id descending
                               select new ChartOfAccountModel()
                               {
                                   Id = ca.Id,
                                   AcountGroup = ca.AcountGroup,
                                   IsActive = ca.IsActive == "Y" ? true : false,
                                   RcaGL = ca.RcaGL,
                                   RcaLedgerTitle = ca.RcaLedgerTitle,
                                   RcaSL = ca.RcaSL,
                                   StatusDate = ca.StatusDate,
                                   SubAcountGroup = ca.SubAcountGroup,
                                   CreatedBy = $"{usr.FirstName} {usr.LastName}",
                                   CreatedAt = ca.CreatedAt,
                               }).ToList();

            return chartOfAccounts;
        }

        public ChartOfAccounts GetById(int id)
        {
            return _dbContext.ChartOfAccounts.FirstOrDefault(t => t.Id == id);
        }

        public async Task<ChartOfAccounts> Update(ChartOfAccounts chartOfAccounts)
        {
            return await UpdateAsync(chartOfAccounts);
        }
    }
}
