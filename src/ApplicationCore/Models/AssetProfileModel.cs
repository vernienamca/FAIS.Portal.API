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
        public int CategoryId { get; set; }
        public int? AssetClass { get; set; }
        public string Description { get; set; }
        public string RcaGLId { get; set; } = string.Empty;
        public long? RCASLId { get; set; } 
        public int? CostCenter { get; set; }
        public int AssetType { get; set; }
        public string EconomicLife { get; set; }
        public string ResidualLife { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public string CreatedByName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedByName { get; set; } = string.Empty;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
