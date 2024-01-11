using DocumentFormat.OpenXml.Office2010.ExcelAc;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FAIS.ApplicationCore.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository repository)
        {
            _roleRepository = repository;
        }

        public IQueryable<Role> Get()
        {
            return _roleRepository.Get();
        }

        public Role GetById(int id)
        {
            return _roleRepository.GetById(id);
        }
    }
}
