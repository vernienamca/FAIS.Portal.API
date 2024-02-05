using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class ChartOfAccountDetails : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ChartOfAccountsId { get; set; }
        [DataMember]
        public long GL { get; set; }
        [DataMember]
        public long SL { get; set; }
        [DataMember]
        public string LedgerTitle { get; set; }
        [DataMember]
        public DateTime DateRemoved { get; set; }
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
