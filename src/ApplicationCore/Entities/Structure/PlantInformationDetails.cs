using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class PlantInformationDetails : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string PlantCode { get; set; }
        [DataMember]
        public int CostCenter { get; set;}
        [DataMember]
        public int? CostCenterTypeLto { get; set; }
        [DataMember]        
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public DateTime? UpdatedAt { get; set;}
        [DataMember]
        public DateTime? DateRemoved { get; set;}
        [DataMember]
        public int CreatedBy { get; set;}
        [DataMember]
        public int? UpdatedBy { get; set;}
    }
}
