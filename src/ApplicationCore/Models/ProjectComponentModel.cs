using System;

namespace FAIS.ApplicationCore.Models
{
    public class ProjectComponentModel
    {
        public int Id { get; set; }
        public int ProjectSeq { get; set; }
        public int ProjectComponentSeq { get; set; }
        public int ProjectStageSeq { get; set; }
        public int TransGridSeq { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
