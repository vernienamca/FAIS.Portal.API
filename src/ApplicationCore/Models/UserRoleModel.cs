using System;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.Models
{
    public class UserRoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IReadOnlyCollection<string> Roles { get; set; }
        public bool IsActive { get; set; }
        public string StatusDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsNew { get; set; }
        public string Email { get; set; }
    }
}

