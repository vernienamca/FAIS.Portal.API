using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Models
{
    public class Amr100BatchDbdModel
    {
        public int Id { get; set; }
        public int ReportSeq { get; set; }
        public DateTime AmrYearMonth { get; set; }
        public int Amr100BatchSeq { get; set; }
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
}
