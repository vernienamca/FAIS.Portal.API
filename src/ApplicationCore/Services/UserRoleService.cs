using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
namespace FAIS.ApplicationCore.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _repository;
        private readonly IRoleRepository _roleRepository;
        public UserRoleService(IUserRoleRepository repository, IRoleRepository roleRepository)
        {
            _repository = repository;
            _roleRepository = roleRepository;
        }

        public async Task<IReadOnlyCollection<UserRole>> Add(RoleDTO roleDTO)
        {
                List<UserRole> userRoles = new List<UserRole>();

                foreach (var roleName in roleDTO.UserRole)
                {
                    var roleId = _roleRepository.GetRoleIdByName(roleName);

                    var userRole = new UserRole()
                    {
                        UserId = roleDTO.Id,
                        RoleId = roleId.Id,
                        IsActive = roleDTO.IsActive,
                        StatusDate = roleDTO.StatusDate,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        CreatedBy = roleDTO.CreatedBy,
                        UpdatedBy = roleDTO.UpdatedBy,
                    };

                    userRoles.Add(await _repository.Add(userRole));
                }
                return userRoles;
        }
           
    }
}
