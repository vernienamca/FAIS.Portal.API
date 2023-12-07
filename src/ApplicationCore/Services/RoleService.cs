using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<Role> Get()
        {
            return _repository.Get();
        }

        public async Task<Role> GetById(int id)
        {
            return await _repository.GetById(id);
        }
    }
}
