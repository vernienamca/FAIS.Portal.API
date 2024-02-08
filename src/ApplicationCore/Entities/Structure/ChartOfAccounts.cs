using FAIS.ApplicationCore.DTOs.Structure;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class ChartOfAccounts : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public long AccountGroupId { get; set; }
        [DataMember]
        public long SubAccountGroupId { get; set; }
        [DataMember]
        public long RcaGL { get; set; }
        [DataMember]
        public long RcaSL { get; set; }
        [DataMember]
        public string RcaLedgerTitle { get; set; }
        [DataMember]
        public string IsActive { get; set; }
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

        public IEnumerable<ChartOfAccountDetails> ChartOfAccountDetails { get; set; }
    }
}
