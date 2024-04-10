using System;

namespace FAIS.ApplicationCore.Models
{
    public class UserRoleModel
    {
        public int Id { get; set; }
        public int UserRoleId { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string StatusDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsNew { get; set; }
    }
}

