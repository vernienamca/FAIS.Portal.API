using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class Jv : BaseEntity<int>
    {
        [DataMember]
        public string No { get; set; }
        [DataMember]
        public int StatusCodeLto { get; set; }
        [DataMember]
        public DateTime StatusDate { get; set; }
        [DataMember]
        public int? PreparedBy { get; set; }
        [DataMember]
        public int? ReviewedBy { get; set; }
        [DataMember]
        public int? ApprovedBy { get; set; }
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
