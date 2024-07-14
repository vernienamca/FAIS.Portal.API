using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Models
{
    public class AmrModel
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
        public string CreatedByName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedByName { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public int ReportTotal { get; set; }
        public int? TotalIssues { get; set; }
        public int? StatusCode { get; set; }
    }
}
