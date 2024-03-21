using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.DTOs
{
    public class AssetProfileDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AssetCategoryId { get; set; }
        public int? AssetClassId { get; set; }
        public string Description { get; set; }
        public int RcaGLId { get; set; }
        public int RcaSLId { get; set; }
        public int CostCenter { get; set; }
        public string EconomicLife { get; set; }
        public string ResidualLife { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public class AddAssetProfileDTO
    {
        public string Name { get; set; }
        public int AssetCategoryId { get; set; }
        public int? AssetClassId { get; set; }
        public string Description { get; set; }
        public int RcaGLId { get; set; }
        public int RcaSLId { get; set; }
        public int CostCenter { get; set; }
        public string EconomicLife { get; set; }
        public string ResidualLife { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
