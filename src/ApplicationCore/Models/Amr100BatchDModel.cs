using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Models
{
    public class Amr100BatchDModel
    {
        public int Id { get; set; }
        public int Amr100BatchSeq { get; set; }
        public int ReportSeq { get; set; }
        public DateTime AmrYearMonth { get; set; }
        public int ReportFg{ get; set; }
        public string ProjectName { get; set; }
        public int ReportTotal { get; set; }
        public int BatchTotal { get; set; }
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
        public DateTime? UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedByName { get; set; }

    }
}
