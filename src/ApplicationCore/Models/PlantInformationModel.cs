﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Models
{
    public class PlantInformationModel
    {
        public string PlantCode { get; set; }
        public string SubstationName { get; set; }
        public string SubstationNameOld { get; set; }
        public int TransGrid { get; set; }
        public string TransGridDescription { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string GmapCoord { get; set; }
        public DateTime? CommissionDate { get; set; }
        public char IsActive { get; set; }
        public int? ClassId { get; set; }
        public int? MtdId { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public int? RegionId { get; set; }
        public int? ProvId { get; set; }
        public int? MunId { get; set; }
        public int? BrgyId { get; set; }
        public DateTime StatusDate { get; set; }
        public string CreatedByName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedByName { get; set; } = string.Empty;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public IReadOnlyCollection<PlantInformationDetailModel> Details { get; set; }
    }
}
