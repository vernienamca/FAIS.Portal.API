using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FAIS.ApplicationCore.DTOs;
using System.Linq;

namespace FAIS.ApplicationCore.Services
{
    public class RolePermissionService: IRolePermissionService
    {
        #region Variables

        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RolePermissionService"/> class.
        /// <param name="rolepermission">The rolepermission repository.</param>
        /// </summary>
        public RolePermissionService(IRolePermissionRepository rolePermissionRepository, 
            IUserService userService, 
            IRoleService roleService, 
            IRoleRepository roleRepository, 
            IModuleRepository moduleRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
            _userService = userService;
            _roleService = roleService;
            _roleRepository = roleRepository;
            _moduleRepository = moduleRepository;
        }

        #endregion Constructor       

        public async Task<List<RoleResponseModelDTO>> GetRolePermission()
        {
            List<RoleResponseModelDTO> roles = new List<RoleResponseModelDTO>();
            List<RolePermissionResponseModelDTO> permissions = new List<RolePermissionResponseModelDTO>();

            foreach (var role in  _roleService.Get())
            {
                var entity = new RoleResponseModelDTO()
                {
                    roleModel = role,
                    rolePermissionModels = await _rolePermissionRepository.GetRolePermissionListByRoleId(role.Id)
                };
                roles.Add(entity);
            }

            return roles;
        }

        public async Task<List<RoleResponseModelDTO>> GetListRolePermission()
        {
            var roles = new List<RoleResponseModelDTO>();
            foreach (var role in _roleService.Get())
            {
                roles.Add(new RoleResponseModelDTO()
                {
                    roleModel = role,
                    rolePermissionModels = await _rolePermissionRepository.GetRolePermissionListByRoleId(role.Id)
                });
            }
            return roles;
        }
        public async Task<RoleResponseModelDTO> GetListRolePermissionById(int id)
        {
            var rolePerm = _roleService.Get().FirstOrDefault(x => x.Id == id);
            return new RoleResponseModelDTO()
            {
                roleModel = rolePerm,
                rolePermissionModels = await _rolePermissionRepository.GetRolePermissionListByRoleId(rolePerm.Id)
            };
        }

        public async Task DeletePermission(int id)
        {
            var rolePermission = _rolePermissionRepository.GetById(id);
            await _rolePermissionRepository.DeleteRolePermissionAsync(rolePermission);
        }

        public async Task UpdateRolePermission(RoleRequestModelDTO roleModelDTO)
        {
            var roleItem = _roleRepository.GetById(roleModelDTO.Id);
            roleItem.Description = roleModelDTO.Description;
            roleItem.Name = roleModelDTO.Name;
            roleItem.IsActive = roleModelDTO.IsActive ? 'Y' : 'N';

            await _roleRepository.Update(roleItem);

            var getRoles = await _rolePermissionRepository.GetRolePermissionListByRoleId(roleModelDTO.Id);
            if (getRoles.Count > 0)
            {
                await _rolePermissionRepository.DeleteRolePermissionListAsync(getRoles.Select(rolePermId => rolePermId.Id).ToList());
            }

            if (roleModelDTO.rolePermissionModels.Count > 0)
            {
                foreach (var item in roleModelDTO.rolePermissionModels)
                {
                    await _rolePermissionRepository.AddRolePermission(new RolePermission()
                    {
                        RoleId = roleModelDTO.Id,
                        ModuleId = item.ModuleId,
                        IsCreate = item.IsCreate ? 'Y' : 'N',
                        IsUpdate = item.IsUpdate ? 'Y' : 'N',
                        IsRead = item.IsRead ? 'Y' : 'N',
                        CreatedAt = DateTime.Now,
                        CreatedBy = roleModelDTO.CreatedById,
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = roleModelDTO.CreatedById
                    });
                }
            }
        }
    }
}
