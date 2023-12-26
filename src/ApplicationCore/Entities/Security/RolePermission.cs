using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Security
{
    public class RolePermission : BaseEntity<decimal>
    {
        [DataMember]
        public decimal Id { get; set; }

        [DataMember]
        public int RoleId { get; set; }

        [DataMember]
        public int ModuleId { get; set; }

        [DataMember]
        public char IsCreate { get; set; }

        [DataMember]
        public char IsRead { get; set; }

        [DataMember]
        public char IsUpdate { get; set; }

        [DataMember]
        public DateTime? DateRemoved { get; set; }

        [DataMember]
        public decimal CreatedBy { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public decimal? UpdatedBy { get; set; }

        [DataMember]
        public DateTime? UpdatedAt { get; set; }
    }
}
