using System;

namespace FAIS.ApplicationCore.Models
{
    public class ChartOfAccountModel
    {
        public int Id { get; set; }
        public long AcountGroup { get; set; }
        public long SubAcountGroup { get; set; }
        public long RcaGL { get; set; }
        public long RcaSL { get; set; }
        public string RcaLedgerTitle { get; set; }
        public bool IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ChartOfAccountDetailModel ChartOfAccountDetailModel { get; set; }
    }
}
