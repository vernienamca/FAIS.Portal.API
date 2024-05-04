using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class ProjectProfileComponent : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ProjectProfileId { get; set; }

        //[DataMember]
        //public int ProjectComponentSeq { get; set; }

        [DataMember]
        public string Details { get; set; }

        [DataMember]
        public int? ProjectStageSeq { get; set; }

        [DataMember]
        public int? TransmissionGridSeq { get; set; }

        [DataMember]
        public DateTime? StartDate { get; set; }

        [DataMember]
        public DateTime? TargetDate { get; set; }

        [DataMember]
        public DateTime? CompletionDate { get; set; }

        [DataMember]
        public DateTime? InspectionDate { get; set; }

        [DataMember]
        public DateTime? InitialAMRMonth { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public DateTime? UpdatedAt { get; set; }

        [DataMember]
        public DateTime? RemoveAt { get; set; }

        [DataMember]
        public int CreatedBy { get; set; }

        [DataMember]
        public int? UpdatedBy { get; set; }
    }
}