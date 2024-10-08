﻿using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System;
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

        public IReadOnlyCollection<PermissionModel> Get()
        {
            return _permissionRepository.Get();
        }

        public IReadOnlyCollection<PermissionModel> GetPermissions(int userId, int moduleId)
        {
            return _permissionRepository.GetPermissions(userId, moduleId);
        }

        public async Task DeletePermission(int id)
        {
            var rolePermission = _permissionRepository.GetById(id);
            await _permissionRepository.Delete(rolePermission);
        }

        public async Task AddPermission(AddPermissionDTO permissionDTO)
        {
            var permissionDto = _mapper.Map<RolePermission>(permissionDTO);
            await _permissionRepository.Add(permissionDto);
        }
        public async Task UpdatePermission(UpdatePermissionDTO permissionDTO)
        {
            var permission = _permissionRepository.GetById(permissionDTO.Id);
            var updatedDto = _mapper.Map(permissionDTO, permission);
            permission.CreatedAt = permission.CreatedAt;
            permission.UpdatedBy = permissionDTO.UpdatedBy;
            await _permissionRepository.Update(permission);
        }

        public async Task UpdateRoleAddPermission(UpdateRolePermissionDTO rolePermission)
        {
            var role = _roleRepository.GetById(rolePermission.RoleId);
            role.Description = rolePermission.Description;
            role.Name = rolePermission.Name;
            role.UpdatedAt = DateTime.Now;
            role.IsActive = rolePermission.IsActive ? 'Y' : 'N';
            role.UpdatedBy = rolePermission.UpdatedBy;
            await _roleRepository.Update(role);

            var permissionMapping = _mapper.Map<List<RolePermission>>(rolePermission.rolePermissionModel);
            await _permissionRepository.AddList(rolePermission.RoleId, permissionMapping);
        }

        public RolePermissionModel GetRolePermissionListByRoleId(int roleId)
        {
            var roleModel = _roleRepository.Get().FirstOrDefault(x=>x.Id == roleId);
            var getPermission = _permissionRepository.Get().Where(perm => perm.RoleId == roleId).ToList();
            var permissionModel = _mapper.Map<List<PermissionModel>>(getPermission);

            return new RolePermissionModel()
            {
                Role = roleModel,
                Permissions = permissionModel.OrderByDescending(x => x.CreatedAt).ToList()
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
