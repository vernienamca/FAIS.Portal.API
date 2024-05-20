using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class PlantInformation : BaseEntity<string>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        public string PlantCode { get; set; }
        [DataMember]
        public string SubstationName { get; set;}
        [DataMember]        
        public string SubstationNameOld { get; set; }
        [DataMember]
        public int? ClassId { get; set; }
        [DataMember]
        public int TransGrid { get; set; }
        [DataMember]
        public int DistrictId { get; set; }
        [DataMember]
        public int? MtdId { get; set; }
        [DataMember]
        public string GmapCoord { get; set; }
        [DataMember]
        public DateTime? CommissionDate { get; set; }
        [DataMember]
        public string UDF1 { get; set; }
        [DataMember]
        public string UDF2 { get; set; }
        [DataMember]
        public string UDF3 { get; set; }
        [DataMember]
        public int? RegionId { get; set; }
        [DataMember]
        public int? ProvId { get; set; }
        [DataMember]
        public int? MunId { get; set; }
        [DataMember]
        public int? BrgyId { get; set; }
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
