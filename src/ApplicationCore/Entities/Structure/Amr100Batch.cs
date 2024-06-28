using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class Amr100Batch : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ReportSeq { get; set; }
        [DataMember]
        public int ReportFgLto { get; set; }
        [DataMember]
        public int ProjectSeq { get; set; }
        [DataMember]
        public int ProjectComponentLto { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string UDF1 { get; set; }
        [DataMember]
        public string UDF2 { get; set; }
        [DataMember]
        public string UDF3 { get; set; }
        [DataMember]
        public int StatusCodeLto { get; set; }
        [DataMember]
        public DateTime StatusDate { get; set; }
        [DataMember]
        public int AccStatusCodeLto { get; set; }
        [DataMember]
        public DateTime AccStatusDate { get; set; }
        [DataMember]
        public int AssignedTo { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public int CreatedBy { get; set; }
        [DataMember]
        public DateTime? UpdatedAt { get; set; }
        [DataMember]
        public int? UpdatedBy { get; set; }
    }
}
