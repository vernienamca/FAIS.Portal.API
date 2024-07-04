using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class Amr100BatchStatHistory : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Amr100BatchSeq { get; set; }
        [DataMember]
        public int StatusCodeLto { get; set; }
        [DataMember]
        public DateTime StatusDate { get; set; }
        [DataMember]
        public string StatusRemarks { get; set; }
        [DataMember]
        public int CreatedBy { get; set; }
        
    }
}
