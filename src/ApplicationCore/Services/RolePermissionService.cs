using DocumentFormat.OpenXml.Office.CustomUI;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IModuleRepository _moduleRepository;

        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public RolePermissionService(IRolePermissionRepository rolePermissionRepository, IUserService userService, IRoleService roleService, IRoleRepository roleRepository, IModuleRepository moduleRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
            _userService = userService;
            _roleService = roleService;
            _roleRepository = roleRepository;
            _moduleRepository = moduleRepository;
        }

        public async Task<List<RoleModelDTO>> GetRolePermission()
        {
            List<RoleModelDTO> roles = new List<RoleModelDTO>();
            List<RolePermissionModelDTO> permissions = new List<RolePermissionModelDTO>();

            foreach (var role in _roleService.Get())
            {
                var createdBy = _userService.GetById(role.CreatedBy);
                var modifiedBy = _userService.GetById(role.UpdatedBy.Value);
                var getRolePermission = _rolePermissionRepository.GetRolePermissionByRoleId((int)role.Id);
                

                var entity = new RoleModelDTO()
                {
                    Id = (int)role.Id,
                    Name = role.Name,
                    Description = role.Description,
                    IsActive = role.IsActive == 'Y',
                    StatusDate = role.StatusDate,
                    CreatedBy = string.Format("{0} {1}", createdBy.FirstName, createdBy.LastName),
                    CreatedAt = role.CreatedAt
                };

                if (modifiedBy != null)
                {
                    entity.UpdatedBy = string.Format("{0} {1}", modifiedBy.FirstName, modifiedBy.LastName);
                    entity.UpdatedAt = role.UpdatedAt;
                }

                if (getRolePermission.Result.Count > 0)
                {
                    foreach (var permission in getRolePermission.Result)
                    {
                        var getModule = _moduleRepository.GetById(permission.ModuleId);
                        permissions.Add(new RolePermissionModelDTO()
                        {
                            Id = (int)permission.Id,
                            ModuleId = (int)permission.ModuleId,
                            RoleId = (int)permission.RoleId,
                            CreatedBy = createdBy.Id,
                            ModuleName = getModule.Name,
                            IsRead = permission.IsCreate == 'Y' ? true : false,
                            IsCreate = permission.IsRead == 'Y' ? true : false,
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

        public async Task<RoleModelDTO> GetRolePermissionById(int id)
        {
            List<RolePermissionModelDTO> permissions = new List<RolePermissionModelDTO>();
            var getRoleById = _roleService.GetById(id);
            var createdBy = _userService.GetById(getRoleById.CreatedBy);
            var modifiedBy = _userService.GetById(getRoleById.UpdatedBy.Value);
            var getRolePermission = _rolePermissionRepository.GetRolePermissionByRoleId((int)id);

            var entity = new RoleModelDTO()
            {
                Id = (int)getRoleById.Id,
                Name = getRoleById.Name,
                Description = getRoleById.Description,
                IsActive = getRoleById.IsActive == 'Y',
                StatusDate = getRoleById.StatusDate,
                CreatedBy = string.Format("{0} {1}", createdBy.FirstName, createdBy.LastName),
                CreatedAt = getRoleById.CreatedAt,
            };

            if (modifiedBy != null)
            {
                entity.UpdatedBy = string.Format("{0} {1}", modifiedBy.FirstName, modifiedBy.LastName);
                entity.UpdatedAt = getRoleById.UpdatedAt;
            }

            if (getRolePermission.Result.Count > 0)
            {
                foreach (var permission in getRolePermission.Result)
                {
                    var getModule = _moduleRepository.GetById((int)permission.ModuleId);
                    permissions.Add(new RolePermissionModelDTO()
                    {
                        Id = (int)permission.Id,
                        ModuleId = (int)permission.ModuleId,
                        RoleId = (int)permission.RoleId,
                        ModuleName = getModule.Name,
                        IsRead = permission.IsCreate == 'Y' ? true : false,
                        IsCreate = permission.IsRead == 'Y' ? true : false,
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

        public async Task<RoleModelDTO> UpdateRolePermission(RoleModelDTO roleModelDTO)
        {
            var roleItem = _roleRepository.GetById(roleModelDTO.Id);
            roleItem.Description = roleModelDTO.Description;
            roleItem.Name = roleModelDTO.Name;
            roleItem.IsActive = roleModelDTO.IsActive ? 'Y':'N';

            await _roleRepository.UpdateRole(roleItem);

            var getRoles = _rolePermissionRepository.GetRolePermissionByRoleId(roleModelDTO.Id);
            if(getRoles.Result.Count > 0)
            {
                await _rolePermissionRepository.DeleteRolePermissionListAsync(getRoles.Result);
            }            

            if(roleModelDTO.rolePermissionModels.Count > 0)
            {
                foreach(var item in roleModelDTO.rolePermissionModels)
                {
                    await _rolePermissionRepository.AddRolePermission(new RolePermission()
                    {
                        RoleId = roleModelDTO.Id,
                        ModuleId = item.ModuleId,                        
                        IsCreate = item.IsRead ? 'Y': 'N',
                        IsUpdate = item.IsUpdate ? 'Y' : 'N',
                        IsRead = item.IsCreate ? 'Y' : 'N',
                        CreatedAt = DateTime.Now,
                        CreatedBy = roleModelDTO.CreatedById,
                        UpdatedAt= DateTime.Now,
                        UpdatedBy= roleModelDTO.CreatedById
                    });
                }
            }

            return roleModelDTO;
        }
    }
}
