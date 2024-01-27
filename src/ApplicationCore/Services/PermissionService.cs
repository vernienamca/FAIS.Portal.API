using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class PermissionService : IPermissionService
    {
        #region Variables

        private readonly IPermissionRepository _permissionRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        #endregion Variables

        #region Constructor
        public PermissionService(IPermissionRepository permissionRepository,
            IRoleRepository roleRepository,
            IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        #endregion

        public async Task DeletePermission(int id)
        {
            var rolePermission = _permissionRepository.GetById(id);
            await _permissionRepository.Delete(rolePermission);
        }

        public async Task AddPermission(PermissionDTO permissionDTO)
        {
            var permissionDto = _mapper.Map<RolePermission>(permissionDTO);
            await _permissionRepository.Add(permissionDto);
        }
        public RolePermissionModel GetRolePermissionListByRoleId(int roleId)
        {
            var getRole = _roleRepository.GetById(roleId);
            var roleModel = _mapper.Map<RoleModel>(getRole);
            var getPermission = _permissionRepository.Get().Where(perm => perm.RoleId == roleId).ToList();
            var permissionModel = _mapper.Map<List<PermissionModel>>(getPermission);

            return new RolePermissionModel()
            {
                Role = roleModel,
                Permissions = permissionModel
            };
        }
        public List<PermissionModel> GetListPermission()
        {
            var getPermission = _permissionRepository.Get().ToList();
            var permissionModel = _mapper.Map<List<PermissionModel>>(getPermission);
            return permissionModel;
        }
        public List<PermissionModel> GetListPermissionByRoleId(int roleId)
        {
            var getPermission = _permissionRepository.Get().Where(perm => perm.RoleId == roleId).ToList();
            var permissionModel = _mapper.Map<List<PermissionModel>>(getPermission);
            return permissionModel;
        }
    }
}
