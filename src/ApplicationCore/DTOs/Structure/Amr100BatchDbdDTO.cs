using System;
using System.Runtime.Serialization;


namespace FAIS.ApplicationCore.DTOs.Structure
{
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
        public DateTime? UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedByName { get; set; }
    }

    public class AddAmr100BatchDbdDTO
    { 
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
        public DateTime? UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }

    }

    public class UpdateAmr100BatchDbdDTO
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
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedByName { get; set; }
    }
    public class AmrTransactionsDTO
    {
        public int Id { get; set; }
        public string Remarks { get; set; }
    }
}
