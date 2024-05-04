using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.DTOs
{
    public class ProjectProfileComponentDTO
    {
        public int Id { get; set; }
        public int ProjectProfileId { get; set; }
        public string Details { get; set; }
        public int? ProjectStageSeq { get; set; }
        public int? TransmissionGridSeq { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? InspectionDate { get; set; }
        public DateTime? InitialAMRMonth { get; set; }
        public DateTime? StatusDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}