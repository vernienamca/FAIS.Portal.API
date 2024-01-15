using System;

namespace FAIS.ApplicationCore.DTOs
{
    public class ModuleDTO
    {
        public decimal Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public char IsActive { get; set; }
      
        public DateTime StatusDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
