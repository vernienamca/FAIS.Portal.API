﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Models
{
    public class MeteringProfileModel
    {
        public int Id { get; set; }
        public int TransGrid { get; set; }
        public string TransGridDescription { get; set; }
        public int DistrictSeq { get; set; }
        public string DistrictDescription { get; set; }
        public string Customer { get; set; }
        public string MeteringPointName { get; set; }
        public string MeteringClassDescription { get; set; }
        public int MeteringClass { get; set; }
        public string InstallationTypeDescription { get; set; }
        public int InstallationTypeSeq { get; set; }
        public int FacilityLocationSeq { get; set; }
        public string FacilityLocationDescription { get; set; }
        public string LineSegment { get; set; }
        public string Remarks { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public int? AdRegionSeq { get; set; }
        public string AdRegionSeqDescription { get; set; }
        public int? AdProvSeq { get; set; }
        public int? AdMunSeq { get; set; }
        public int? AdBrgySeq { get; set; }
        public char IsActive { get; set; }
        public string CreatedByName { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public string UpdatedByName { get; set; } = string.Empty;
        public int? UpdatedBy { get; set; }
    }
}