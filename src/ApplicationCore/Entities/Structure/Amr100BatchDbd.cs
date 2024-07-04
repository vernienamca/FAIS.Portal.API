using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class Amr100BatchDbd : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Amr100BatchDbdSeq { get; set; }
        [DataMember]
        public int Amr100BatchDSeq { get; set; }
        [DataMember]
        public int AmrSeq { get; set; }
        [DataMember]
        public char NewAsset { get; set; }
        [DataMember]
        public int? ArSeq { get; set; }
        [DataMember]
        public int AmrAssetSeq { get; set; }
        [DataMember]
        public char WithIssues { get; set; }
        [DataMember]
        public int AllocatedCost { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string NgcpAssetId { get; set; }
        [DataMember]
        public string TransactionDetails { get; set; }
        [DataMember]
        public string TransactionDesc { get; set; }
        [DataMember]
        public string LineSegment { get; set; }
        [DataMember]
        public string UDF1 { get; set; }
        [DataMember]
        public string UDF2 { get; set; }
        [DataMember]
        public string UDF3 { get; set; }
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
