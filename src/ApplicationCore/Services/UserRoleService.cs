using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            _userRepository = userRepository;
        }



        public async Task<IReadOnlyCollection<UserRoleModel>> Add(UserRoleModel userRoleModel)
        {
            List<UserRoleModel> userRoles = new List<UserRoleModel>();

            //var existingRoles = _repository.GetUserRolesById(userRoleModel.UserId).ToList();

            //Debug.WriteLine($"Existing Roles for User ID {userRoleModel.UserId}: {string.Join(", ", existingRoles.Select(r => $"{r.Name} (ID: {r.Id})"))}");

            //foreach (var userRole in userRoleModel.Roles)
            //{
            //    Debug.WriteLine("RoleID" + userRole.RoleId);
            //    Debug.WriteLine("ExistingRoleId" + userRoleModel.UserId);

            //    // Find existing role
            //    //var existingRole = existingRoles.FirstOrDefault(r => r.RoleId == userRole.RoleId);
            //    if (existingRoles.Any(existingRole => existingRole.RoleId == userRole.RoleId ))
            //    {

            //        //existingRole.IsActive = userRole.IsActive;
            //        //await _repository.Update(existingRole);
            //        continue;
            //    }

            //    var userRoleEntity = new UserRole
            //    {
            //        UserId = userRoleModel.UserId,
            //        RoleId = userRole.RoleId,
            //        StatusDate = DateTime.Now,
            //        CreatedAt = DateTime.Now,
            //        UpdatedAt = DateTime.Now,
            //        CreatedBy = userRoleModel.CreatedBy,
            //        IsActive = userRole.IsActive,
            //    };

            //    var savedUserRole = await _repository.Add(userRoleEntity);

            //    // Convert to USER_ROLE MODEL
            //    //var savedUserRoleModel = new UserRoleModel
            //    //{
            //    //    UserId = savedUserRole.UserId,
            //    //    Roles = new List<UserRoles>
            //    //    {
            //    //        new UserRoles
            //    //        {
            //    //            RoleName = userRole.RoleName,
            //    //            IsActive = userRole.IsActive,
            //    //            RoleId = userRole.RoleId,
            //    //            CreatedBy = userRole.CreatedBy,
            //    //        }
            //    //    }
            //    //};

            //    //Debug.WriteLine($"Added role {userRole.RoleName} (ID: {userRole.RoleId}) for the user.");

            //    //userRoles.Add(savedUserRoleModel);
            //}

            return userRoles;
        }


    }
}



