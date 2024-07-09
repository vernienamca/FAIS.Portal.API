using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class DefinedTableColumns : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int? DefinedTableId { get; set; }

        [DataMember]
        public string ColumName { get; set; }

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
