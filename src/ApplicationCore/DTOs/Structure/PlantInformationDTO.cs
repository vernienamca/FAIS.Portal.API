using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

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
        public string Status { get; set; }
        [JsonIgnore]
        public DateTime StatusDate { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public IReadOnlyCollection<PlantInfoDetails> Details { get; set; }
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
        public IReadOnlyCollection<PlantInfoDetails> Details { get; set; }
    }

    public class PlantInfoDetails
    {
        public int? Id { get; set; }
        public string TempKey { get; set; }
        public string PlantCode { get; set; }
        public int? CostCenterType { get; set; }
        public string CostCenterNo { get; set; }
        public bool IsRemoved { get; set; }
        [JsonIgnore]
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
