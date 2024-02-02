using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IChartOfAccountsRepository
    {
        IReadOnlyCollection<ChartOfAccountModel> Get();
        ChartOfAccounts GetById(int id);
        Task<ChartOfAccounts> Add(ChartOfAccounts chartOfAccounts);
        Task<ChartOfAccounts> Update(ChartOfAccounts chartOfAccounts);
    }
}
