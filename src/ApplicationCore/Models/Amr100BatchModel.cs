using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Models
{
    public class Amr100BatchModel
    {
        public int Id { get; set; }
        public DateTime AmrYearMonth { get; set; }
        public int ReportSeq { get; set; }
        public int ReportFgLto{ get; set; }
        public int ProjectSeq { get; set; }
        public string ProjectName { get; set; }
        public int ProjectComponentLto { get; set; }
        public string Remarks { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public int StatusCode { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime AccStatusDate { get; set; }
        public int AssignedTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedByName { get; set; }
        public int TotalAmrIssues { get; set; }
        public int TotalReport { get; set; }
    }
}
