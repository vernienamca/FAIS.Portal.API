using System;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.Models
{
    public class ProjectProfileModel
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int ProjStageSeq { get; set; }
        public string ProjectStageName { get; set; }
        public string Remarks { get; set; }
        public int ProjClassSeq { get; set; }
        public string ProjectClassName { get; set; }
        public DateTime TpsrMonth { get; set; }
        public DateTime? LatestInspectionDate { get; set; }
        public int? TotalAmrCost { get; set; }
        public int? NoOfComponentsCompleted { get; set; }
        public int? NoOfComponentsUnderConstruction { get; set; }
        public int? RecordedAMR { get; set; }
        public int? UnrecordedAMR { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByName { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedByName { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public List<ProjectProfileComponentModel> ProjectProfileComponents { get; set; }
    }
}
