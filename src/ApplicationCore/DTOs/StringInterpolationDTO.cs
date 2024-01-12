using System.Runtime.Serialization;
using System;

namespace FAIS.ApplicationCore.DTOs
{
    public class StringInterpolationDTO
    {
        public decimal Id { get; set; }
        public string TransactionCode { get; set; }
        public string TransactionDescription { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public string NotificationType { get; set; }
        public decimal CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public decimal UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
