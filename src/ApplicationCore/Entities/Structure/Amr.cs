using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class Amr : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime AmrYm { get; set; }
        [DataMember]
        public DateTime DateReceivedTransco { get; set; }
        [DataMember]
        public DateTime DateReceivedArmPmd { get; set; }
        [DataMember]
        public DateTime? DateSentEncoding { get; set; }
        [DataMember]
        public DateTime? DateEndorsed { get; set; }
        [DataMember]
        public int NoOfBinders { get; set; }
        [DataMember]
        public string UDF1 { get; set; }
        [DataMember]
        public string UDF2 { get; set; }
        [DataMember]
        public string UDF3 { get; set; }
        [DataMember]
        public int CreatedBy { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public int? UpdatedBy { get; set; }
        [DataMember]
        public DateTime? UpdatedAt { get; set; }
        [DataMember]
        public int? StatusCode { get; set; }
    }
}
