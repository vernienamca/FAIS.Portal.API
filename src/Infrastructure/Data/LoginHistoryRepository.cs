using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class LoginHistoryRepository : EFRepository<LoginHistory, int>, ILoginHistoryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginHistoryRepository"/> class.
        /// </summary>
        public LoginHistoryRepository(FAISContext context) : base(context)
        {
        }

        public IQueryable<LoginHistory> Get()
        {
            return _dbContext.LoginHistory;
        }

        public async Task<LoginHistory> Add(LoginHistory history)
        {
            return await AddAsync(history);
        }
    }
}
