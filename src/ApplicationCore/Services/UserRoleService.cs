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
        private readonly IUserRepository _userRepository;
        public UserRoleService(IUserRoleRepository repository, IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _repository = repository;
            _roleRepository = roleRepository;
            _userRepository= userRepository;
        }

        public async Task<IReadOnlyCollection<UserRole>> Add(RoleDTO roleDTO)
        {
            int userId = await _userRepository.GetLastUserId();
            List<UserRole> userRoles = new List<UserRole>();

                foreach (var roleName in roleDTO.UserRole)
                {
                    var roleId = _roleRepository.GetRoleIdByName(roleName);

                    var userRole = new UserRole()
                    {
                        UserId = userId,
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
