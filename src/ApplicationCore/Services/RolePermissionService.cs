using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FAIS.ApplicationCore.DTOs;
using System.Data.Entity;
using DocumentFormat.OpenXml.Vml.Office;
using DocumentFormat.OpenXml.Office2010.Excel;

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
        public RolePermissionService(IRolePermissionRepository rolePermissionRepository, IUserService userService, IRoleService roleService, IRoleRepository roleRepository, IModuleRepository moduleRepository)
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
                var getRolePermission = _rolePermissionRepository.GetRolePermissionByRoleId((int)role.Id);


                var entity = new RoleResponseModelDTO()
                {
                    Id = (int)role.Id,
                    Name = role.Name,
                    Description = role.Description,
                    IsActive = role.IsActive == 'Y',
                    StatusDate = role.StatusDate,
                    CreatedBy = role.CreatedBy,
                    CreatedAt = role.CreatedAt
                };

                if (role.UpdatedBy != null)
                {
                    entity.UpdatedBy = role.UpdatedBy;
                    entity.UpdatedAt = role.UpdatedAt;
                }

                if (getRolePermission.Count > 0)
                {
                    foreach (var permission in getRolePermission)
                    {
                        var getModule = _moduleRepository.GetById(permission.ModuleId);
                        permissions.Add(new RolePermissionResponseModelDTO()
                        {
                            Id = (int)permission.Id,
                            ModuleId = (int)permission.ModuleId,
                            RoleId = (int)permission.RoleId,
                            ModuleName = getModule.Name,
                            IsCreate = permission.IsCreate == 'Y' ? true : false,
                            IsRead = permission.IsRead == 'Y' ? true : false,
                            IsUpdate = permission.IsUpdate == 'Y' ? true : false,
                            DateRemoved = permission.DateRemoved
                        });
                    }
                }
                entity.rolePermissionModels = permissions;
                roles.Add(entity);
            }

            return roles;
        }

        public async Task<List<RoleResponseModelDTO>> GetListRolePermission()
        {
            var roles = new List<RoleResponseModelDTO>();
            var permissions = new List<RolePermissionResponseModelDTO>();
            foreach (var role in _roleService.Get())
            {
                var roleitem = new RoleResponseModelDTO()
                {
                    Id = (int)role.Id,
                    Name = role.Name,
                    Description = role.Description,
                    IsActive = role.IsActive == 'Y',
                    StatusDate = role.StatusDate,
                    CreatedBy = role.CreatedBy,
                    CreatedAt = role.CreatedAt,
                };
                if (role.UpdatedBy != null)
                {
                    roleitem.UpdatedBy = role.UpdatedBy;
                    roleitem.UpdatedAt = role.UpdatedAt;
                }
                foreach (var permission in _rolePermissionRepository.GetRolePermissionByRoleId(role.Id))
                {
                    var getModule = _moduleRepository.GetById((int)permission.ModuleId);
                    permissions.Add(new RolePermissionResponseModelDTO()
                    {
                        Id = (int)permission.Id,
                        ModuleId = (int)permission.ModuleId,
                        RoleId = (int)permission.RoleId,
                        ModuleName = getModule.Name,
                        IsRead = permission.IsRead == 'Y' ? true : false,
                        IsCreate = permission.IsCreate == 'Y' ? true : false,
                        IsUpdate = permission.IsUpdate == 'Y' ? true : false,
                        DateRemoved = permission.DateRemoved
                    });
                }
                roleitem.rolePermissionModels = permissions;
                roles.Add(roleitem);
            }
            return roles;
        }

        public async Task<RoleResponseModelDTO> GetRolePermissionById(int id)
        {
                var permissions = new List<RolePermissionResponseModelDTO>();
                var getRoleById = _roleService.GetById(id);
                var createdBy = _userService.GetById(getRoleById.CreatedBy);
                var modifiedBy = _userService.GetById(getRoleById.UpdatedBy.Value);
                var getRolePermission = _rolePermissionRepository.GetRolePermissionByRoleId((int)id);

                var entity = new RoleResponseModelDTO()
                {
                    Id = (int)getRoleById.Id,
                    Name = getRoleById.Name,
                    Description = getRoleById.Description,
                    IsActive = getRoleById.IsActive == 'Y',
                    StatusDate = getRoleById.StatusDate,
                    CreatedBy = string.Format("{0} {1}", createdBy.Result.FirstName, createdBy.Result.LastName),
                    CreatedAt = getRoleById.CreatedAt,
                };

                if (modifiedBy != null)
                {
                    entity.UpdatedBy = string.Format("{0} {1}", modifiedBy.Result.FirstName, modifiedBy.Result.LastName);
                    entity.UpdatedAt = getRoleById.UpdatedAt;
                }

                if (getRolePermission.Count > 0)
                {
                    foreach (var permission in getRolePermission)
                    {
                        var getModule = _moduleRepository.GetById((int)permission.ModuleId);
                        permissions.Add(new RolePermissionResponseModelDTO()
                        {
                            Id = (int)permission.Id,
                            ModuleId = (int)permission.ModuleId,
                            RoleId = (int)permission.RoleId,
                            ModuleName = getModule.Name,
                            IsRead = permission.IsRead == 'Y' ? true : false,
                            IsCreate = permission.IsCreate == 'Y' ? true : false,
                            IsUpdate = permission.IsUpdate == 'Y' ? true : false,
                            DateRemoved = permission.DateRemoved
                        });
                    }
                }
                entity.rolePermissionModels = permissions;
                return entity;
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

            var getRoles = _rolePermissionRepository.GetRolePermissionByRoleId(roleModelDTO.Id);
            if (getRoles.Count > 0)
            {
                await _rolePermissionRepository.DeleteRolePermissionListAsync(getRoles);
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
