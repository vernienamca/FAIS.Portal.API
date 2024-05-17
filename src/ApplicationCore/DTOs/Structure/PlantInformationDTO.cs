using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.DTOs
{
    public class PlantInformationDTO
    {
        public string PlantCode { get; set; }
        public string SubstationName { get; set; }
        public string SubstationNameOld { get; set; }
        public int? ClassId { get; set; }
        public int TransGrid { get; set; }
        public int DistrictId { get; set; }
        public int? MtdId { get; set; }
        public string GmapCoord { get; set; }
        public DateTime? CommissionDate { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public int? RegionId { get; set; }
        public int? ProvId { get; set; }
        public int? MunId { get; set; }
        public int? BrgyId { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
    public class AddPlantInformationDTO
    {
        public string PlantCode { get; set; }
        public string SubstationName { get; set; }
        public string SubstationNameOld { get; set; }
        public int? ClassId { get; set; }
        public int TransGrid { get; set; }
        public int DistrictId { get; set; }
        public int? MtdId { get; set; }
        public string GmapCoord { get; set; }
        public DateTime? CommissionDate { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public int? RegionId { get; set; }
        public int? ProvId { get; set; }
        public int? MunId { get; set; }
        public int? BrgyId { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
    public class UpdatePlantInformationDTO
    {
        public string PlantCode { get; set; }
        public string SubstationName { get; set; }
        public string SubstationNameOld { get; set; }
        public int? ClassId { get; set; }
        public int TransGrid { get; set; }
        public int DistrictId { get; set; }
        public int? MtdId { get; set; }
        public string GmapCoord { get; set; }
        public DateTime? CommissionDate { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public int? RegionId { get; set; }
        public int? ProvId { get; set; }
        public int? MunId { get; set; }
        public int? BrgyId { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
