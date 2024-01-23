using System;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.DTOs
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public IReadOnlyCollection<string> UserRole { get; set; }
    }
}
