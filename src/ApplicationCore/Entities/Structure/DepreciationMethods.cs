using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class DepreciationMethods : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public int? BusinessProcessId { get; set; }

        [DataMember]
        public char IsSingleTransaction { get; set; }

        [DataMember]
        public int? FinalResultId { get; set; }

        [DataMember]
        public char IsActive { get; set; }

        [DataMember]
        public DateTime StatusDate { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public DateTime? UpdatedAt { get; set; }

        [DataMember]
        public int CreatedBy { get; set; }

        [DataMember]
        public int? UpdatedBy { get; set; }
    }
}
