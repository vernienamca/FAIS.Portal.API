using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class UserRoleRepository : EFRepository<UserRole, int>, IUserRoleRepository
    {
        public UserRoleRepository(FAISContext context) : base(context)
        {
        }
        public async Task<UserRole> Add(UserRole userRole)
        {
            return await AddAsync(userRole);
        }
    }
}
