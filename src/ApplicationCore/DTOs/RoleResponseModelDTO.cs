using System.Collections.Generic;
using System;
using FAIS.ApplicationCore.Models;

namespace FAIS.ApplicationCore.DTOs
{
    public class RoleResponseModelDTO
    {
        public RoleModel roleModel { get; set; }
        public List<RolePermissionResponseModelDTO> rolePermissionModels { get; set; }
    }
    public class RolePermissionResponseModelDTO
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public bool IsCreate { get; set; }
        public bool IsRead { get; set; }
        public bool IsUpdate { get; set; }
        public DateTime? DateRemoved { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
