using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class PermissionService : IPermissionService
    {
        #region Variables

        private readonly IPermissionRepository _permissionRepository;
        private readonly IRoleRepository _roleRepository;

        #endregion Variables

        #region Constructor
        public PermissionService(IPermissionRepository permissionRepository,
            IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
        }
        #endregion

        public async Task DeletePermission(int id)
        {
            var rolePermission = _permissionRepository.GetById(id);
            await _permissionRepository.Delete(rolePermission);
        }

        //public async Task AddPermission(PermissionDTO permissionDTO)
        //{
        //    await _permissionRepository.Add(rolePermission);
        //}
    }
}
