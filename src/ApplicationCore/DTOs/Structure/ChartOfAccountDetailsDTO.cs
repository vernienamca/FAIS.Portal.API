using System;

namespace FAIS.ApplicationCore.DTOs.Structure
{
    public class ChartOfAccountDetailsDTO
    {
        public int Id { get; set; }
        public int ChartOfAccountsId { get; set; }
        public long GL { get; set; }
        public long SL { get; set; }
        public string LedgerTitle { get; set; }
        public DateTime? DateRemoved { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
