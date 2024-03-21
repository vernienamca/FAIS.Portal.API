using System;
using System.Collections.Generic;
using System.Text;

namespace FAIS.ApplicationCore.Models
{
    public class AssetProfileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int? AssetClass { get; set; }
        public string Description { get; set; } 
        public long RcaGLId { get; set; }
        public long RCASLId { get; set; } 
        public int CostCenter { get; set; }
        public string EconomicLife { get; set; }
        public string ResidualLife { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
