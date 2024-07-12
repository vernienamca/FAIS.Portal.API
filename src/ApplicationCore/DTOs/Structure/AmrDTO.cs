using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.DTOs
{
    public class AmrDTO
    {
        public int Id { get; set; }
        public DateTime AmrYm { get; set; }
        public DateTime DateReceivedTransco { get; set; }
        public DateTime DateReceivedArmPmd { get; set; }
        public DateTime? DateSentEncoding { get; set; }
        public DateTime? DateEndorsed { get; set; }
        public int NoOfBinders { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
    public class Amr100BatchDTO
    {
        public int Id { get; set; }
        public DateTime AmrYearMonth { get; set; }
        public int ReportSeq { get; set; }
        public int ReportFgLto { get; set; }
        public int ProjectSeq { get; set; }
        public string ProjectName { get; set; }
        public int ProjectComponentLto { get; set; }
        public string Remarks { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public int StatusCode { get; set; }
        public DateTime StatusDate { get; set; }
        public int AccStatusCodeLto { get; set; }
        public DateTime AccStatusDate { get; set; }
        public int AssignedTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public int? UpdatedBy { get; set; } 
        public string UpdatedByName { get; set; }
    }
    public class Amr100BatchDDTO
    {
        public int Id { get; set; }
        public int Amr100BatchSeq { get; set; }
        public int RoaSeq { get; set; }
        public int FgLto { get; set; }
        public string AmrLocation { get; set; }
        public string AmrWbsNo { get; set; }
        public string AmrAssetNo { get; set; }
        public string AmrAsset { get; set; }
        public string AmrProjectName { get; set; }
        public int AmrEconomicLife { get; set; }
        public int AmrCost { get; set; }
        public DateTime? AmrCompletionDate { get; set; }
        public int AmrAssetClass { get; set; }
        public int AmrReferenceNo { get; set; }
        public int Qty { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public char IsReturnedToEncoder { get; set; }
        public char IsReturnedToAnalysis { get; set; }
        public int ProformaEntrySeq { get; set; }
        public string Remarks { get; set; }
        public int StatusCodeLto { get; set; }
        public DateTime? StatusDate { get; set; }
        public int AccStatusCodeLto { get; set; }
        public DateTime AccStatusDate { get; set; }
        public int AssignedTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedByName { get; set; }
    }
    public class Amr100BatchDbdDTO
    {
        public int Id { get; set; }
        public int Amr100BatchDSeq { get; set; }
        public int AmrSeq { get; set; }
        public char NewAsset { get; set; }
        public int? ArSeq { get; set; }
        public int AmrAssetSeq { get; set; }
        public char WithIssues { get; set; }
        public int AllocatedCost { get; set; }
        public string Remarks { get; set; }
        public string NgcpAssetId { get; set; }
        public string TransactionDetails { get; set; }
        public string TransactionDesc { get; set; }
        public string LineSegment { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedByName { get; set; }
    }

}
