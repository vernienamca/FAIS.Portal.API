using System;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.DTOs
{
    public class RoleModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int CreatedById { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UpdatedById { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<RolePermissionModelDTO> rolePermissionModels { get; set; }
    }
    public class RolePermissionModelDTO
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public bool IsCreate { get; set; }
        public bool IsRead { get; set; }
        public bool IsUpdate { get; set; }
        public DateTime? DateRemoved { get; set; }

        public decimal CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
