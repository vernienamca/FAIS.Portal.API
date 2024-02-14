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
                               join dtl in _dbContext.ChartOfAccountDetails.AsNoTracking() on ca.Id equals dtl.ChartOfAccountsId 
                                    into joinedAccounts from dtl in joinedAccounts.DefaultIfEmpty()
                               join libT in _dbContext.LibraryTypes.AsNoTracking() on ca.AccountGroupId equals libT.Id 
                                    into joinedTypes from libT in joinedTypes.DefaultIfEmpty()
                               join libO in _dbContext.LibraryOptions.AsNoTracking() on ca.SubAccountGroupId equals libO.Id 
                                    into joinedOptions from libO in joinedOptions.DefaultIfEmpty()
                               orderby ca.Id descending
                               select new ChartOfAccountModel()
                               {
                                   Id = ca.Id,
                                   AcountGroup = libT.Name,
                                   IsActive = ca.IsActive == "Y" ? true : false,
                                   RcaGL = ca.RcaGL,
                                   RcaLedgerTitle = ca.RcaLedgerTitle,
                                   RcaSL = ca.RcaSL,
                                   StatusDate = ca.StatusDate,
                                   SubAcountGroup = libO.Description,
                                   CreatedBy = $"{usr.FirstName} {usr.LastName}",
                                   CreatedAt = ca.CreatedAt,
                                   UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                                   UpdatedAt = ca.UpdatedAt
                               }).ToList();

            return chartOfAccounts;
        }

        public ChartOfAccountModel GetById(int id)
        {
            var chartOfAccount = (from ca in _dbContext.ChartOfAccounts.AsNoTracking()
                                   join usr in _dbContext.Users.AsNoTracking() on ca.CreatedBy equals usr.Id
                                   join usrU in _dbContext.Users.AsNoTracking() on ca.UpdatedBy equals usrU.Id 
                                        into joinedUsers from usrU in joinedUsers.DefaultIfEmpty()
                                   join libT in _dbContext.LibraryTypes.AsNoTracking() on ca.AccountGroupId equals libT.Id 
                                        into joinedTypes from libT in joinedTypes.DefaultIfEmpty()
                                   join libO in _dbContext.LibraryOptions.AsNoTracking() on ca.SubAccountGroupId equals libO.Id 
                                        into joinedOptions from libO in joinedOptions.DefaultIfEmpty()
                                   orderby ca.Id descending
                                   select new ChartOfAccountModel()
                                   {
                                       Id = ca.Id,
                                       AcountGroup = libT.Name,
                                       IsActive = ca.IsActive == "Y" ? true : false,
                                       RcaGL = ca.RcaGL,
                                       RcaLedgerTitle = ca.RcaLedgerTitle,
                                       RcaSL = ca.RcaSL,
                                       StatusDate = ca.StatusDate,
                                       SubAcountGroup = libO.Description,
                                       CreatedBy = $"{usr.FirstName} {usr.LastName}",
                                       CreatedAt = ca.CreatedAt,
                                       UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                                       UpdatedAt = ca.UpdatedAt
                                   }).FirstOrDefault(t => t.Id == id);

            if (chartOfAccount != null)
            {
                var chartOfAccountDetails = (from d in _dbContext.ChartOfAccountDetails.AsNoTracking()
                                             join usr in _dbContext.Users.AsNoTracking() on d.CreatedBy equals usr.Id
                                             join usrU in _dbContext.Users.AsNoTracking() on d.UpdatedBy equals usrU.Id
                                                  into joinedUsers
                                             from usrU in joinedUsers.DefaultIfEmpty()
                                             orderby d.Id descending
                                             select new ChartOfAccountDetailModel
                                             {
                                                 Id = d.Id,
                                                 ChartOfAccountsId = d.ChartOfAccountsId,
                                                 CreatedAt = d.CreatedAt,
                                                 CreatedBy = $"{usr.FirstName} {usr.LastName}",
                                                 DateRemoved = d.DateRemoved.GetValueOrDefault(),
                                                 GL = d.GL,
                                                 LedgerTitle = d.LedgerTitle,
                                                 SL = d.SL,
                                                 UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                                                 UpdatedAt = d.UpdatedAt,
                                             })
                                             .Where(d => d.ChartOfAccountsId == chartOfAccount.Id)
                                             .ToList();

                chartOfAccount.ChartOfAccountDetailModel = chartOfAccountDetails.ToList();
            }

            return chartOfAccount;
        }

        public async Task<ChartOfAccounts> Update(ChartOfAccounts chartOfAccounts)
        {
            return await UpdateAsync(chartOfAccounts);
        }
    }
}
