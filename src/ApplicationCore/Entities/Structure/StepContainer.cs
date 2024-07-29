using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class StepContainer : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int DefinedMethodId { get; set; }

        [DataMember]
        public int ParentId { get; set; }

        [DataMember]
        public int SortOrder { get; set; }

        [DataMember]
        public int StepType { get; set; }

        [DataMember]
        public int FieldDictionaryId { get; set; }

        [DataMember]
        public char IsElse { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public string Comments { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public DateTime? UpdatedAt { get; set; }

        [DataMember]
        public int CreatedBy { get; set; }

        [DataMember]
        public int? UpdatedBy { get; set; }

        [DataMember]
        public DateTime? RemovedAt { get; set; }
    }
}
