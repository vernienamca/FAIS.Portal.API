

using System;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.DTOs
{
    public class PermissionDTO
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string GroupName { get; set; }
        public bool IsCreate { get; set; }
        public bool IsRead { get; set; }
        public bool IsUpdate { get; set; }
    }
    public class AddPermissionDTO
    {
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string GroupName { get; set; }
        public bool IsCreate { get; set; }
        public bool IsRead { get; set; }
        public bool IsUpdate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
    }

    public class UpdatePermissionDTO
    {
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public bool IsCreate { get; set; }
        public bool IsRead { get; set; }
        public bool IsUpdate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }

    public class UpdateRolePermissionDTO
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int UpdatedBy { get; set; }
        public List<UpdatePermissionDTO> rolePermissionModel { get; set; }
    }
}
