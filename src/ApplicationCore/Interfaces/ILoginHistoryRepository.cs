using FAIS.ApplicationCore.Entities.Security;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface ILoginHistoryRepository
    {
        IQueryable<LoginHistory> Get();
        Task<LoginHistory> Add(LoginHistory history);
        Task<DateTime?> GetLastLoginDate(int id);
    }
}
