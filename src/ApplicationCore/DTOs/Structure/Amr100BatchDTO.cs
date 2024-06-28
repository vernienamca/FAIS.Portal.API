using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.DTOs.Structure
{
    public class Amr100BatchDTO
    {
        public int Id { get; set; }
        public int ReportSeq { get; set; }
        public int ReportFgLto { get; set; }
        public int ProjectSeq { get; set; }
        public int ProjectComponentLto { get; set; }
        public string Remarks { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public int StatusCodeLto { get; set; }
        public DateTime StatusDate { get; set; }
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

    public class AddAmr100BatchDTO
    {
        public int ReportSeq { get; set; }
        public int ReportFgLto { get; set; }
        public int ProjectSeq { get; set; }
        public int ProjectComponentLto { get; set; }
        public string Remarks { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public int StatusCodeLto { get; set; }
        public DateTime StatusDate { get; set; }
        public int AccStatusCodeLto { get; set; }
        public DateTime AccStatusDate { get; set; }
        public int AssignedTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
    }
    
    public class UpdateAmr100BatchDTO
    {
        public int Id { get; set; }
        public int ReportSeq { get; set; }
        public int ReportFgLto { get; set; }
        public int ProjectSeq { get; set; }
        public int ProjectComponentLto { get; set; }
        public string Remarks { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public int StatusCodeLto { get; set; }
        public DateTime StatusDate { get; set; }
        public int AccStatusCodeLto { get; set; }
        public DateTime AccStatusDate { get; set; }
        public int AssignedTo { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
