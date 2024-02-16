using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class ChartOfAccountDetailsRepository : EFRepository<ChartOfAccountDetails, int>, IChartOfAccountDetailsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChartOfAccountDetailsRepository"/> class.
        /// </summary>
        public ChartOfAccountDetailsRepository(FAISContext context) : base(context) { }

        public async Task<ChartOfAccountDetails> Add(ChartOfAccountDetails chartOfAccountDetails)
        {
            return await AddAsync(chartOfAccountDetails);
        }

        public IReadOnlyCollection<ChartOfAccountDetailModel> Get()
        {
            var chartOfAccounts = (from ca in _dbContext.ChartOfAccountDetails.AsNoTracking()
                                   join usr in _dbContext.Users.AsNoTracking() on ca.CreatedBy equals usr.Id
                                   join usrU in _dbContext.Users.AsNoTracking() on ca.UpdatedBy equals usrU.Id
                                   orderby ca.Id descending
                                   select new ChartOfAccountDetailModel()
                                   {
                                       Id = ca.Id,
                                       ChartOfAccountsId = ca.ChartOfAccountsId,
                                       LedgerTitle = ca.LedgerTitle,
                                       SL = ca.SL,
                                       GL = ca.GL,
                                       DateRemoved = ca.DateRemoved.GetValueOrDefault(),
                                       CreatedBy = $"{usr.FirstName} {usr.LastName}",
                                       CreatedAt = ca.CreatedAt,
                                       UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                                       UpdatedAt = ca.UpdatedAt,
                                   }).ToList();

            return chartOfAccounts;
        }

        public ChartOfAccountDetails GetById(int id)
        {
            return _dbContext.ChartOfAccountDetails.FirstOrDefault(t => t.Id == id);
        }

        public List<ChartOfAccountDetails> GetByChartOfAccountId(int id)
        {
            return _dbContext.ChartOfAccountDetails.Where(t => t.ChartOfAccountsId == id).ToList();
        }

        public async Task<ChartOfAccountDetails> Update(ChartOfAccountDetails chartOfAccountDetails)
        {
            return await UpdateAsync(chartOfAccountDetails);
        }
    }
}
