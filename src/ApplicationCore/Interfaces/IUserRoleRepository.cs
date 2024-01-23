using FAIS.ApplicationCore.Entities.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<UserRole> Add(UserRole userRole);
    }
}
