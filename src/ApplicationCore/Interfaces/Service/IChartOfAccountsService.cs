using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Service
{
    public interface IChartOfAccountsService
    {
        IReadOnlyCollection<ChartOfAccountModel> Get();
        ChartOfAccountModel GetById(int id);
        Task<ChartOfAccounts> Add(ChartOfAccountsDTO chartOfAccountsDTO);
        Task<ChartOfAccounts> Update(ChartOfAccountsDTO chartOfAccountsDTO);
        byte[] ExportChartofAccounts();
    }
}
