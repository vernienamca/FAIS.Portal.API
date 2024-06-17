using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.DTOs
{
    public class ProjectProfileDTO
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int ProjStageSeq { get; set; }
        public string Remarks { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public int ProjClassSeq { get; set; }
        public DateTime TpsrMonth { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? RemoveAt { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public IEnumerable<ProjectProfileComponentDTO> ProjectProfileComponentsDTO { get; set; }
    }

    public class AddProjectProfileDTO
    {
        public string ProjectName { get; set; }
        public int ProjStageSeq { get; set; }
        public string Remarks { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public int ProjClassSeq { get; set; }
        public DateTime TpsrMonth { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
        public IEnumerable<ProjectProfileComponentDTO> ProjectProfileComponentsDTO { get; set; }
    }
}