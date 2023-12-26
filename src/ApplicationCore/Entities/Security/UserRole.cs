using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Security
{
    public class UserRole : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int RoleId { get; set; }

        [DataMember]
        public char IsActive { get; set; }

        [DataMember]
        public DateTime StatusDate { get; set; }

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
