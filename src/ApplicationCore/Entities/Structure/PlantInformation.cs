using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class PlantInformation : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string PlantCode { get; set; }
        [DataMember]
        public string SubstationName { get; set;}
        [DataMember]        
        public string SubstationNameOld { get; set; }
        [DataMember]
        public int? ClassSeq{ get; set; }
        [DataMember]
        public int TransGrid { get; set; }
        [DataMember]
        public int DistrictSeq { get; set; }
        [DataMember]
        public int? MidSeq { get; set; }
        [DataMember]
        public string? GmapCoord { get; set; }
        [DataMember]
        public DateTime? CommissionDate { get; set; }
        [DataMember]
        public string UDF1 { get; set; }
        [DataMember]
        public string UDF2 { get; set; }
        [DataMember]
        public string UDF3 { get; set; }
        [DataMember]
        public int? RegionSeq { get; set; }
        [DataMember]
        public int? ProvSeq { get; set; }
        [DataMember]
        public int? MunSeq { get; set; }
        [DataMember]
        public int? BrgySeq { get; set; }
        [DataMember]
        public char IsActive { get; set; }
        [DataMember]
        public DateTime StatusDate { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set;}
        [DataMember]
        public int CreatedBy { get; set;}
        [DataMember]
        public DateTime? UpdatedAt { get; set; }
        [DataMember]
        public int? UpdatedBy { get; set;}


    }
}
