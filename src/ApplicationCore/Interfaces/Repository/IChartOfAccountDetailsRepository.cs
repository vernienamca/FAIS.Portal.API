using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces.Repository
{
    public interface IChartOfAccountDetailsRepository
    {
        IReadOnlyCollection<ChartOfAccountDetailModel> Get();
        ChartOfAccountDetails GetById(int id);
        ChartOfAccountDetails GetByChartOfAccountId(int id);
        Task<ChartOfAccountDetails> Add(ChartOfAccountDetails chartOfAccountDetails);
        Task<ChartOfAccountDetails> Update(ChartOfAccountDetails chartOfAccountDetails);
    }
}
