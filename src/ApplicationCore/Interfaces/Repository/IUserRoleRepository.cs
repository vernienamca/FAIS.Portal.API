﻿using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IUserRoleRepository
    {
        IReadOnlyCollection<UserRole> Get();
        Task<UserRole> Add(UserRole userRole);
        Task<UserRole> Update(UserRole userRole);
        IReadOnlyCollection<UserRoleModel> GetUserRolesById(int id);
    }
}
