using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class ProjectComponent : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ProjectSeq { get; set; }
        [DataMember]
        public int ProjectComponentSeq { get; set; }
        [DataMember]
        public int ProjectStageSeq { get; set; }
        [DataMember]
        public int TransGridSeq { get; set; }
        [DataMember]
        public DateTime? StartDate { get; set; }
        [DataMember]
        public DateTime? TargetDate { get; set; }
        [DataMember]
        public DateTime? CompletionDate { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public DateTime? UpdatedAt { get; set; }
        [DataMember]
        public DateTime? DeletedAt { get; set; }
        [DataMember]
        public int CreatedBy { get; set; }
        [DataMember]
        public int? UpdatedBy { get; set; }
    }
}
