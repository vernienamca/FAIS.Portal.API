using System;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.Models
{
    public class ChartOfAccountModel
    {
        public int Id { get; set; }
        public string AcountGroup { get; set; }
        public long AccountGroupId { get; set; }
        public string SubAcountGroup { get; set; }
        public long subAccountGroupId { get; set; }
        public long RcaGL { get; set; }
        public long RcaSL { get; set; }
        public string RcaLedgerTitle { get; set; }
        public bool IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<ChartOfAccountDetailModel> ChartOfAccountDetailModel { get; set; }
    }
}
