using DocumentFormat.OpenXml.InkML;
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
        public string Users { get; set; }

        [DataMember]
        public string Roles { get; set; }

        [DataMember]
        public string Icon { get; set; }

        [DataMember]
        public int? IconColor { get; set; }

        [DataMember]
        public int? NotificationType { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public DateTime? StartDate { get; set; }

        [DataMember]
        public string StartTime { get; set; }

        [DataMember]
        public DateTime? EndDate { get; set; }

        [DataMember]
        public string EndTime { get; set; }

        [DataMember]
        public int Target { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public char IsActive { get; set; }

        [DataMember]
        public DateTime StatusDate { get; set; }

        [DataMember]
        public int CreatedBy { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public int? UpdatedBy { get; set; }

        [DataMember]
        public DateTime? UpdatedAt { get; set; }
    }
}
