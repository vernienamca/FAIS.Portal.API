using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class StringInterpolation : BaseEntity<decimal>
    {
        [DataMember]
        public decimal Id { get; set; }
        [DataMember]
        public string TransactionCode { get; set; }
        [DataMember]
        public string TransactionDescription { get; set; }
        [DataMember]
        public char IsActive { get; set; }
        [DataMember]
        public DateTime StatusDate { get; set; }
        [DataMember]
        public string NotificationType { get; set; }
        [DataMember]
        public decimal CreatedBy { get; set; }
        [DataMember]
        public DateTime? CreatedAt { get; set; }
        [DataMember]
        public decimal? UpdatedBy { get; set; }
        [DataMember]
        public DateTime? UpdatedAt { get; set; }
    }
}
