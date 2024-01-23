using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class Template : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public int Receiver { get; set; }

        [DataMember]
        public int? NotificationType { get; set; }

        [DataMember]
        public char IsActive { get; set; }

        [DataMember]
        public DateTime StatusDate { get; set; }

        [DataMember]
        public int CreatedBy { get; set; }

        [DataMember]
        public DateTime? CreatedAt { get; set; }

        [DataMember]
        public int? UpdatedBy { get; set; }

        [DataMember]
        public DateTime? UpdatedAt { get; set; }
    }
}
