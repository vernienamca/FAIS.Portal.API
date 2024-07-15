using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class Amr100BatchD : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Amr100BatchSeq { get; set; }
        [DataMember]
        public int RoaSeq { get; set; }
        [DataMember]
        public int FgLto { get; set; }
        [DataMember]
        public string AmrLocation { get; set; }
        [DataMember]
        public string AmrWbsNo { get; set; }
        [DataMember]
        public string AmrAssetNo { get; set; }
        [DataMember]
        public string AmrAsset { get; set; }
        [DataMember]
        public string AmrProjectName { get; set; }
        [DataMember]
        public int AmrEconomicLife { get; set; }
        [DataMember]
        public int AmrCost { get; set; }
        [DataMember]
        public DateTime? AmrCompletionDate { get; set; }
        [DataMember]
        public int AmrAssetClass { get; set; }
        [DataMember]
        public int AmrReferenceNo { get; set; }
        [DataMember]
        public int Qty { get; set; }
        [DataMember]
        public string UDF1 { get; set; }
        [DataMember]
        public string UDF2 { get; set; }
        [DataMember]
        public string UDF3 { get; set; }
        [DataMember]
        public char IsReturnedToEncoder { get; set; }
        [DataMember]
        public char IsReturnedToAnalysis { get; set; }
        [DataMember]
        public int ProformaEntrySeq { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public int StatusCodeLto { get; set; }
        [DataMember]
        public DateTime? StatusDate { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public int CreatedBy { get; set; }
        [DataMember]
        public DateTime? UpdatedAt { get; set; }
        [DataMember]
        public int? UpdatedBy { get; set; }
        [DataMember]
        public int? ColumnBreaks { get; set; }
    }
}
