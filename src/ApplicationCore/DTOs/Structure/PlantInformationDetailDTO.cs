using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.DTOs
{
    public class PlantInformationDetailDTO
    {
        public int Id { get; set; }
        public string PlantCode { get; set; }
        public int CostCenter { get; set; }
        public int? CostCenterTypeLto { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
    public class AddPlantInformationDetailDTO
    {
        public int CostCenter { get; set; }
        public int? CostCenterTypeLto { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
    public class UpdatePlantInformationDetailDTO
    {
        public int Id { get; set; }
        public int CostCenter { get; set; }
        public int? CostCenterTypeLto { get; set; }
        public DateTime? RemovedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
