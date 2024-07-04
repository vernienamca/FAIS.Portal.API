using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Models
{
    public class ProjectProfileComponentModel
    {
        public int Id { get; set; }
        public int ProjectProfileSeq { get; set; }
        public string ComponentName { get; set; }
        public string Details { get; set; }
        public int? ProjectStageSeq { get; set; }
        public int? TransmissionGridSeq { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? InspectionDate { get; set; }
        public DateTime? InitialAmrMonth { get; set; }
        public int? TotalAmrCost { get; set; }
        public int? RecordedAmr { get; set; }
        public int? UnrecordedAmr { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}