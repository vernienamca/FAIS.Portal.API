using System;

namespace FAIS.ApplicationCore.DTOs.Structure
{
    public class ChartOfAccountsDTO
    {
        public int Id { get; set; }
        public long AcountGroup { get; set; }
        public long SubAcountGroup { get; set; }
        public long RcaGL { get; set; }
        public long RcaSL { get; set; }
        public string RcaLedgerTitle { get; set; }
        public string IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
