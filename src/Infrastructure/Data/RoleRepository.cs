using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class RoleRepository : EFRepository<Role, int>, IRoleRepository
    {
        public RoleRepository(FAISContext context) : base(context)
        {
        }

        public IQueryable<Role> Get()
        {
            return _dbContext.Roles;
        }

        public async Task<Role> GetById(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
