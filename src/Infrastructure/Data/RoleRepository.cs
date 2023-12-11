using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System.Linq;

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

        public Role GetById(int id)
        {
            return _dbContext.Roles.Where(t => t.Id == id).ToList()[0];
        }
    }
}
