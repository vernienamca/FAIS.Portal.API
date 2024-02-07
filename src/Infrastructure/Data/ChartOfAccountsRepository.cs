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
                               join usrU in _dbContext.Users.AsNoTracking() on ca.UpdatedBy equals usrU.Id 
                                    into joinedUsers from usrU in joinedUsers.DefaultIfEmpty()
                               join detail in _dbContext.ChartOfAccountDetails.AsNoTracking() on ca.Id equals detail.ChartOfAccountsId 
                                    into joinedAccounts from detail in joinedAccounts.DefaultIfEmpty()
                               join libType in _dbContext.LibraryTypes.AsNoTracking() on ca.AccountGroupId equals libType.Id 
                                    into joinedTypes from libType in joinedTypes.DefaultIfEmpty()
                               join libOptions in _dbContext.LibraryOptions.AsNoTracking() on ca.SubAccountGroupId equals libOptions.Id 
                                    into joinedOptions from libOptions in joinedOptions.DefaultIfEmpty()
                               orderby ca.Id descending
                               select new ChartOfAccountModel()
                               {
                                   Id = ca.Id,
                                   AcountGroup = libType.Name,
                                   IsActive = ca.IsActive == "Y" ? true : false,
                                   RcaGL = ca.RcaGL,
                                   RcaLedgerTitle = ca.RcaLedgerTitle,
                                   RcaSL = ca.RcaSL,
                                   StatusDate = ca.StatusDate,
                                   SubAcountGroup = libOptions.Description,
                                   CreatedBy = $"{usr.FirstName} {usr.LastName}",
                                   CreatedAt = ca.CreatedAt,
                                   UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                                   UpdatedAt = ca.UpdatedAt,
                                   ChartOfAccountDetailModel = new ChartOfAccountDetailModel
                                   {
                                       Id = detail.Id,
                                       ChartOfAccountsId = detail.ChartOfAccountsId,
                                       CreatedAt = detail.CreatedAt,
                                       CreatedBy = $"{usr.FirstName} {usr.LastName}",
                                       DateRemoved = detail.DateRemoved.GetValueOrDefault(),
                                       GL = detail.GL,
                                       LedgerTitle = detail.LedgerTitle,
                                       SL = detail.SL,
                                       UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                                       UpdatedAt = ca.UpdatedAt,
                                   }
                               }).ToList();

            return chartOfAccounts;
        }

        public ChartOfAccountModel GetById(int id)
        {
            var chartOfAccount = (from ca in _dbContext.ChartOfAccounts.AsNoTracking()
                                   join usr in _dbContext.Users.AsNoTracking() on ca.CreatedBy equals usr.Id
                                   join usrU in _dbContext.Users.AsNoTracking() on ca.UpdatedBy equals usrU.Id 
                                        into joinedUsers from usrU in joinedUsers.DefaultIfEmpty()
                                   join detail in _dbContext.ChartOfAccountDetails.AsNoTracking() on ca.Id equals detail.ChartOfAccountsId 
                                        into joinedAccounts from detail in joinedAccounts.DefaultIfEmpty()
                                   join libType in _dbContext.LibraryTypes.AsNoTracking() on ca.AccountGroupId equals libType.Id 
                                        into joinedTypes from libType in joinedTypes.DefaultIfEmpty()
                                   join libOptions in _dbContext.LibraryOptions.AsNoTracking() on ca.SubAccountGroupId equals libOptions.Id 
                                        into joinedOptions from libOptions in joinedOptions.DefaultIfEmpty()
                                   orderby ca.Id descending
                                   orderby ca.Id descending
                                   select new ChartOfAccountModel()
                                   {
                                       Id = ca.Id,
                                       AcountGroup = libType.Name,
                                       IsActive = ca.IsActive == "Y" ? true : false,
                                       RcaGL = ca.RcaGL,
                                       RcaLedgerTitle = ca.RcaLedgerTitle,
                                       RcaSL = ca.RcaSL,
                                       StatusDate = ca.StatusDate,
                                       SubAcountGroup = libOptions.Description,
                                       CreatedBy = $"{usr.FirstName} {usr.LastName}",
                                       CreatedAt = ca.CreatedAt,
                                       UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                                       UpdatedAt = ca.UpdatedAt,
                                       ChartOfAccountDetailModel = new ChartOfAccountDetailModel
                                       {
                                           Id = detail.Id,
                                           ChartOfAccountsId = detail.ChartOfAccountsId,
                                           CreatedAt = detail.CreatedAt,
                                           CreatedBy = $"{usr.FirstName} {usr.LastName}",
                                           DateRemoved = detail.DateRemoved.GetValueOrDefault(),
                                           GL = detail.GL,
                                           LedgerTitle = detail.LedgerTitle,
                                           SL = detail.SL,
                                           UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                                           UpdatedAt = ca.UpdatedAt,
                                       }
                                   }).FirstOrDefault(t => t.Id == id);

            return chartOfAccount;
        }

        public async Task<ChartOfAccounts> Update(ChartOfAccounts chartOfAccounts)
        {
            return await UpdateAsync(chartOfAccounts);
        }
    }
}
