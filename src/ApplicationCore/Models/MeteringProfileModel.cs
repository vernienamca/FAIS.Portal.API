using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Models
{
    public class MeteringProfileModel
    {
        public int Id { get; set; }
        public int TransGrid { get; set; }
        public int DistrictSeq { get; set; }
        public string Customer { get; set; }
        public string MeteringPointName { get; set; }
        public int InstallationTypeSeq { get; set; }
        public int FacilityLocationSeq { get; set; }
        public string Remarks { get; set; }
        public int? AdRegionSeq { get; set; }
        public int? AdProvSeq { get; set; }
        public int? AdMunSeq { get; set; }
        public int? AdBrgySeq { get; set; }
        public string IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
