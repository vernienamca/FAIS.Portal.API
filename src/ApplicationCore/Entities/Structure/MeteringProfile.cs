using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class MeteringProfile : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int TransGrid { get; set; }
        [DataMember]
        public int DistrictSeq { get; set; }
        [DataMember]
        public string Customer { get; set; }
        [DataMember]
        public string MeteringPointName { get; set; }
        [DataMember]
        public int InstallationTypeSeq { get; set; }
        [DataMember]
        public int FacilityLocationSeq { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public int? AdRegionSeq { get; set; }
        [DataMember]
        public int? AdProvSeq { get; set; }
        [DataMember]
        public int? AdMunSeq { get; set; }
        [DataMember]
        public int? AdBrgySeq { get; set; }
        [DataMember]
        public char IsActive { get; set; }
        [DataMember]
        public DateTime StatusDate { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public DateTime? UpdatedAt { get; set; }
        [DataMember]
        public int CreatedBy { get; set; }
        [DataMember]
        public int? UpdatedBy { get; set; }
    }
}
