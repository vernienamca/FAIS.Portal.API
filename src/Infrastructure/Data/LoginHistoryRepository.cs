using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<DateTime?> GetLastLoginDate(int userId)
        {
            var lastLogin = await _dbContext.LoginHistory.Where(x => x.UserId == userId).OrderByDescending(x => x.CreatedAt).Select(x => (DateTime?)x.CreatedAt).FirstOrDefaultAsync();
            return lastLogin;
        }
    }
}
