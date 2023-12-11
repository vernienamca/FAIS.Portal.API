using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System.Linq;

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

        public Role GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
