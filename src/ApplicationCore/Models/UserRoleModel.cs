using FAIS.ApplicationCore.Entities.Security;
using System;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.Models
{
    public class UserRoleModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public List<UserRoles> Roles { get; set; }
        public int CreatedBy { get; set; }
        public char IsActive { get; set; }

        public string Name { get; set; }
    }

    public class UserRoles
    {
        public string RoleName { get; set; }
        public char IsActive { get; set; }
        public int RoleId { get; set; }
        public int CreatedBy { get; set; }
    }
}

