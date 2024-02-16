using System;

namespace FAIS.ApplicationCore.Models
{
    public class ChartOfAccountDetailModel
    {
        public int Id { get; set; }
        public int ChartOfAccountsId { get; set; }
        public long GL { get; set; }
        public long SL { get; set; }
        public string LedgerTitle { get; set; }
        public DateTime? DateRemoved { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
