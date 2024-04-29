using System;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.DTOs
{
    public class ProjectProfileDTO
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int ProjectStageSeq { get; set; }
        public string Remarks { get; set; }
        public int ProjClassSeq { get; set; }
        public DateTime TpsrMonth { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public IEnumerable<ProjectProfileComponentDTO> ProjectProfileComponentsDTO { get; set; }
    }
}